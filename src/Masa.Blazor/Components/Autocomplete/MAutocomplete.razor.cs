﻿using Masa.Blazor.Components.Select;

namespace Masa.Blazor;

public partial class MAutocomplete<TItem, TItemValue, TValue> : MSelect<TItem, TItemValue, TValue>
{
    private Func<TItem, string, string, bool>? _filter;

    [Parameter]
    [MasaApiParameter(true)]
    public bool AllowOverflow { get; set; } = true;

    [Parameter]
    public bool AutoSelectFirst { get; set; }

    [Parameter]
    [MasaApiParameter("(item, query, text) => text.IndexOf(query, StringComparison.OrdinalIgnoreCase) > -1")]
    public Func<TItem, string, string, bool> Filter
    {
        get { return _filter ??= (_, query, text) => text.IndexOf(query, StringComparison.OrdinalIgnoreCase) > -1; }
        set => _filter = value;
    }

    [Parameter]
    public bool HideNoData { get; set; }

    [Parameter]
    public bool NoFilter
    {
        get => GetValue<bool>();
        set => SetValue(value);
    }

    [Parameter]
    public string? SearchInput { get; set; }

    [Parameter]
    public EventCallback<string> OnSearchInputUpdate { get; set; }

    protected override List<TItem> ComputedItems => FilteredItems;

    public override Action<TextFieldNumberProperty>? NumberProps { get; set; }

    protected IList<TItemValue?> SelectedValues => SelectedItems.Select(u => GetValue(u.Item)).ToList();

    protected bool HasDisplayedItems => HideSelected ? FilteredItems.Any(item => !HasItem(item)) : FilteredItems.Count > 0;

    protected bool HasItem(TItem item)
    {
        return SelectedValues.IndexOf(GetValue(item)) > -1;
    }

    private bool _prevNoFilter;
    private bool _prevSearching;
    private string? _prevInternalSearch;
    private IList<TItem>? _prevItems;

    protected List<TItem>? FilteredItems
    {
        get
        {
            bool changed = false;
            
            if (_prevNoFilter != NoFilter)
            {
                _prevNoFilter = NoFilter;
                changed = true;
            }

            if (_prevSearching != IsSearching)
            {
                _prevSearching = IsSearching;
                changed = true;
            }

            if (_prevInternalSearch != InternalSearch)
            {
                _prevInternalSearch = InternalSearch;
                changed = true;
            }

            if (!Equals(_prevItems, Items))
            {
                _prevItems = Items;
                changed = true;
            }

            if (!changed)
            {
                return field ??= AllItems;
            }
            
            if (!IsSearching || NoFilter || InternalSearch is null)
            {
                field = AllItems;
            }
            else
            {
                field = AllItems.Where(item => Filter(item, InternalSearch, GetText(item) ?? "")).ToList();
            }

            if (field.Count == 0)
            {
                _ = SetMenuIndex(-1);
            }
            
            return field;
        }
    }

    protected bool IsSearching
    {
        get
        {
            if (Multiple && SearchIsDirty) return true;
            var text = SelectedItem is null ? null : SelectedItem.InputText ?? GetText(SelectedItem.Item);
            return SearchIsDirty && InternalSearch != text;
        }
    }

    internal SelectedItem<TItem>? SelectedItem => SelectedItems.LastOrDefault();

    protected bool SearchIsDirty => !string.IsNullOrEmpty(InternalSearch);

    protected string? InternalSearch
    {
        get => GetValue<string?>();
        set => SetValue(value);
    }

    protected override Dictionary<string, object> InputAttrs => new(Attributes)
    {
        { "type", Type },
        { "autocomplete", "off" }
    };

    protected override BMenuProps GetDefaultMenuProps()
    {
        var props = base.GetDefaultMenuProps();

        props.OffsetY = true;
        props.OffsetOverflow = true;
        props.Transition = null;

        return props;
    }

    protected override bool IsDirty => SearchIsDirty || base.IsDirty;

    protected bool HasSlot => HasChips || SelectionContent != null;

    protected override bool MenuCanShow
    {
        get
        {
            if (!IsFocused) return false;

            return HasDisplayedItems || !HideNoData;
        }
    }

    protected override IEnumerable<string> KeysForKeyDownWithPreventDefault { get; } = [];

    protected override void RegisterWatchers(PropertyWatcher watcher)
    {
        base.RegisterWatchers(watcher);

        watcher
            .Watch<string>(nameof(InternalSearch), OnInternalSearchChanged)
            .Watch<List<TItem>>(nameof(FilteredItems), OnFilteredItemsChanged);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
    
        SetSearch();
    }

    private static Block _block = new("m-autocomplete");
    private ModifierBuilder _modifierBuilder = _block.CreateModifierBuilder();

    protected override IEnumerable<string> BuildComponentClass()
    {
        return base.BuildComponentClass().Concat(
            new[] { _modifierBuilder.Add("is-selecting-index", SelectedIndex > -1).Build() }
        );
    }

    protected virtual void OnInternalSearchChanged(string? val)
    {
        _ = SetValueByJsInterop(val);
    }

    protected override async Task OnIsFocusedChange(bool val)
    {
        if (val)
        {
            await Js.InvokeVoidAsync(JsInteropConstants.Select, InputElement);
        }
        else
        {
            await Blur();
            await UpdateSelf();
        }
    }

    internal override async Task SelectItem(SelectedItem<TItem> item, bool closeOnSelect = true)
    {
        await base.SelectItem(item, closeOnSelect);
        SetSearch();
    }

    protected override void SetSelectedItems()
    {
        base.SetSelectedItems();

        if (!IsFocused)
        {
            SetSearch();
        }
    }

    public override async Task HandleOnInputAsync(ChangeEventArgs args)
    {
        if (SelectedIndex > -1)
        {
            await SetValueByJsInterop(string.Empty);
            return;
        }

        var value = args.Value?.ToString();

        if (!string.IsNullOrEmpty(value))
        {
            ActivateMenu();
        }

        if (!Multiple && value == "")
        {
            await DeleteCurrentItem();
        }

        InternalSearch = value;

        if (OnSearchInputUpdate.HasDelegate)
        {
            await OnSearchInputUpdate.InvokeAsync(InternalSearch);
        }
    }

    private async Task DeleteCurrentItem()
    {
        var curIndex = SelectedIndex;
        var curItem = SelectedItems.ElementAtOrDefault(curIndex);

        if (!IsInteractive || (curItem is not null && GetDisabled(curItem)))
        {
            return;
        }

        var lastIndex = SelectedItems.Count - 1;

        if (SelectedIndex == -1 && lastIndex != 0)
        {
            SelectedIndex = lastIndex;
            return;
        }

        var length = SelectedItems.Count;
        var nextIndex = curIndex != length - 1 ? curIndex : curIndex - 1;
        var nextItem = SelectedItems.ElementAtOrDefault(nextIndex);

        if (nextItem is null)
        {
            await SetsValue(Multiple ? (TValue)(IList<TItemValue>)new List<TItemValue>() : default);
        }
        else
        {
            await SelectItem(curItem);
        }

        SelectedIndex = nextIndex;
    }

    public override async Task HandleOnKeyDownAsync(KeyboardEventArgs args)
    {
        var keyCode = args.Key;

        if (args.CtrlKey || !new[] { KeyCodes.Home, KeyCodes.End }.Contains(keyCode))
        {
            await base.HandleOnKeyDownAsync(args);
        }

        await ChangeSelectedIndex(keyCode);
    }

    protected override async Task OnTabDown(KeyboardEventArgs args)
    {
        await base.OnTabDown(args);
        await UpdateSelf();
    }

    protected override Task OnUpDown(string code)
    {
        ActivateMenu();
        return Task.CompletedTask;
    }

    public override async Task HandleOnClickAsync(ExMouseEventArgs args)
    {
        if (!IsInteractive) return;

        if (SelectedIndex > -1)
        {
            SelectedIndex = -1;
        }
        else
        {
            await HandleOnFocusAsync(new FocusEventArgs());
        }

        if (args.Target != null && !await IsAppendInner(args.Target))
        {
            ActivateMenu();
        }
    }

    public override async Task HandleOnClearClickAsync(MouseEventArgs args)
    {
        if (!string.IsNullOrEmpty(InternalSearch))
        {
            InternalSearch = null;
        }

        await base.HandleOnClearClickAsync(args);
    }

    private async void OnFilteredItemsChanged(IList<TItem>? val, IList<TItem>? oldVal)
    {
        val ??= new List<TItem>();
        oldVal ??= new List<TItem>();

        var except = val.Except(oldVal);
        if (!except.Any())
        {
            return;
        }

        if (!AutoSelectFirst)
        {
            var preSelectedItem = oldVal.ElementAtOrDefault(MenuListIndex);
            if (preSelectedItem is not null)
            {
                await SetMenuIndex(val.IndexOf(preSelectedItem));
            }
            else
            {
                await SetMenuIndex(-1);
            }
        }

        StateHasChanged();

        NextTick(async () =>
        {
            if (string.IsNullOrEmpty(InternalSearch) || (val.Count != 1 && !AutoSelectFirst))
            {
                await SetMenuIndex(-1);
            }

            if (AutoSelectFirst && val.Count > 0)
            {
                await SetMenuIndex(0);
            }

            StateHasChanged();
        });
    }

    private async Task ChangeSelectedIndex(string keyCode)
    {
        if (SearchIsDirty) return;

        if (Multiple && keyCode == KeyCodes.ArrowLeft)
        {
            if (SelectedIndex == -1)
            {
                SelectedIndex = SelectedItems.Count - 1;
            }
            else
            {
                SelectedIndex--;
            }
        }
        else if (Multiple && keyCode == KeyCodes.ArrowRight)
        {
            if (SelectedIndex >= SelectedItems.Count - 1)
            {
                SelectedIndex = -1;
            }
            else
            {
                SelectedIndex++;
            }
        }
        else if (keyCode is KeyCodes.Backspace or KeyCodes.Delete)
        {
            await DeleteCurrentItem();
        }
    }

    protected virtual Task UpdateSelf()
    {
        if (!SearchIsDirty && !EqualityComparer<TValue>.Default.Equals(InternalValue, default))
        {
            return Task.CompletedTask;
        }

        SetSearch();

        return Task.CompletedTask;
    }

    private void SetSearch()
    {
        NextTick(() =>
        {
            if (!Multiple || string.IsNullOrEmpty(InternalSearch) || !IsMenuActive)
            {
                InternalSearch = (SelectedItems.Count == 0 || Multiple || HasSlot)
                    ? null
                    : GetText(SelectedItem);
                StateHasChanged();
            }
        });
    }
}