﻿using System.Diagnostics.CodeAnalysis;
using Masa.Blazor.Components.ItemGroup;
using StyleBuilder = Masa.Blazor.Core.StyleBuilder;

namespace Masa.Blazor
{
    public partial class MButton : MRoutableGroupItem<MItemGroupBase>, IThemeable
    {
        public MButton() : base(GroupType.ButtonGroup, "button")
        {
        }

        [Inject] private MasaBlazor MasaBlazor { get; set; } = null!;

        public bool Default { get; set; } = true;

        [Parameter] public bool Absolute { get; set; }

        [Parameter] public bool Bottom { get; set; }

        [Parameter] public bool Depressed { get; set; }

        [Parameter] public StringNumber? Elevation { get; set; }

        [Parameter] public virtual bool Icon { get; set; }

        [Parameter] public bool Fab { get; set; }

        [Parameter] public bool Fixed { get; set; }

        [Parameter] public bool Large { get; set; }

        [Parameter] public bool Left { get; set; }

        [Parameter] public bool Plain { get; set; }

        [Parameter] public bool Right { get; set; }

        [Parameter] public bool Rounded { get; set; }

        [Parameter] public bool Small { get; set; }

        [Parameter] public bool Text { get; set; }

        [Parameter] public bool Tile { get; set; }

        [Parameter]
        public string Type
        {
            get => TypeAttribute;
            set => TypeAttribute = value;
        }

        [Parameter] public bool Top { get; set; }

        [Parameter] public bool XLarge { get; set; }

        [Parameter] public bool XSmall { get; set; }

        [Parameter] public bool Ripple { get; set; } = true;

        [Parameter] public bool Block { get; set; }

        [Parameter] public string? Color { get; set; }

        [Parameter] public StringNumber? Height { get; set; }

        [Parameter] public RenderFragment? LoaderContent { get; set; }

        [Parameter] public virtual bool Loading { get; set; }

        [Parameter] public StringNumber? MaxHeight { get; set; }

        [Parameter] public StringNumber? MaxWidth { get; set; }

        [Parameter] public StringNumber? MinHeight { get; set; }

        [Parameter] public StringNumber? MinWidth { get; set; }

        [Parameter] public bool Outlined { get; set; }

        [Parameter] public StringNumber? Width { get; set; }

        [Parameter] public bool OnClickStopPropagation { get; set; }

        [Parameter] public bool OnClickPreventDefault { get; set; }

        [Parameter] public bool? Show { get; set; }

        [Parameter] public string? Key { get; set; }

        [Parameter]
        [MasaApiParameter(ReleasedIn = "v1.5.0")]
        public string? IconName { get; set; }

        [Parameter]
        [MasaApiParameter(ReleasedIn = "v1.5.0")]
        public string? LeftIconName { get; set; }

        [Parameter]
        [MasaApiParameter(ReleasedIn = "v1.5.0")]
        public string? RightIconName { get; set; }

        [Parameter]
        [MasaApiParameter(ReleasedIn = "v1.10.0")]
        public string? ActiveColor { get; set; }

        /// <summary>
        /// Determine whether rendering a loader component
        /// </summary>
        protected bool HasLoader { get; set; }

        /// <summary>
        /// Set the button's type attribute
        /// </summary>
        protected string TypeAttribute { get; set; } = "button";

        [MemberNotNullWhen(true, nameof(IconName))]
        protected bool HasBuiltInIcon => !string.IsNullOrWhiteSpace(IconName);

        private bool IsIconBtn => Icon || HasBuiltInIcon;

        private bool HasBackground => !(IsIconBtn || Plain || Outlined || Text);

        private bool IsRound => IsIconBtn || Fab;

        private bool IsElevated => !(IsIconBtn || Text || Outlined || Depressed || Disabled || Plain) &&
                                   (Elevation == null || Elevation.TryGetNumber().number > 0);

        protected override bool AfterHandleEventShouldRender() => false;

        private static Block _block = new("m-btn");
        private ModifierBuilder _blockModifierBuilder = _block.CreateModifierBuilder();

        protected override IEnumerable<string> BuildComponentClass()
        {
            yield return _blockModifierBuilder
                .Add(Absolute)
                .Add(Block)
                .Add(Bottom)
                .Add(Disabled)
                .Add(IsElevated)
                .Add(Fab)
                .Add(Fixed)
                .Add("has-bg", HasBackground)
                .Add("icon", IsIconBtn)
                .Add(Left)
                .Add(Loading)
                .Add(Outlined)
                .Add(Plain)
                .Add(Right)
                .Add("round", IsRound)
                .Add(Rounded)
                .Add(Text)
                .Add(Tile)
                .Add(Top)
                .Add("active", InternalIsActive)
                .AddClass(ComputedActiveClass, InternalIsActive)
                .AddClass(CssClassUtils.GetSize(XSmall, Small, Large, XLarge))
                .AddTheme(ComputedTheme)
                .AddBackgroundColor(Color, HasBackground)
                .AddTextColor(Color, !HasBackground)
                .AddTextColor(ActiveColor, InternalIsActive)
                .AddElevation(Elevation)
                .Build();
        }

        protected override IEnumerable<string> BuildComponentStyle()
        {
            return StyleBuilder.Create()
                .AddHeight(Height)
                .AddWidth(Width)
                .AddMinWidth(MinWidth)
                .AddMaxWidth(MaxWidth)
                .AddMinHeight(MinHeight)
                .AddMaxHeight(MaxHeight)
                .AddColor(Color, IsIconBtn || Outlined || Plain || Text)
                .GenerateCssStyles();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            HasLoader = true;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            Attributes["ripple"] = Ripple;

            if (OnClick.HasDelegate || ItemGroup is not null)
            {
                Attributes["onclick"] = EventCallback.Factory.Create<MouseEventArgs>(this, HandleOnClick);
            }
        }

        protected async Task HandleOnClick(MouseEventArgs args)
        {
            if (!Fab && args.Detail > 0)
            {
                await Js.InvokeVoidAsync(JsInteropConstants.Blur, Ref);
            }

            await OnClick.InvokeAsync(args);

            await ToggleAsync();
        }
    }
}