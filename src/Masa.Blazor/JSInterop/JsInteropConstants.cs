﻿namespace Masa.Blazor;

public static class JsInteropConstants
{
    private static string JsInteropFuncNamePrefix => "MasaBlazor.interop.";

    public static string GetDomInfo => $"{JsInteropFuncNamePrefix}getDomInfo";

    public static string GetScrollParent => $"{JsInteropFuncNamePrefix}getScrollParent";

    public static string GetScrollTop => $"{JsInteropFuncNamePrefix}getScrollTop";

    public static string TriggerEvent => $"{JsInteropFuncNamePrefix}triggerEvent";

    public static string GetBoundingClientRect => $"{JsInteropFuncNamePrefix}getBoundingClientRect";
        
    public static string GetParentClientWidthOrWindowInnerWidth => $"{JsInteropFuncNamePrefix}getParentClientWidthOrWindowInnerWidth";

    /// <summary>
    /// Add an event listener to an HTML element, returning a unique ID for the listener.
    /// </summary>
    public static string AddHtmlElementEventListener => $"{JsInteropFuncNamePrefix}addHtmlElementEventListener";

    /// <summary>
    /// Remove an event listener from an HTML element using the unique ID returned by AddHtmlElementEventListener.
    /// </summary>
    public static string RemoveHtmlElementEventListener => $"{JsInteropFuncNamePrefix}removeHtmlElementEventListener";

    public static string Contains => $"{JsInteropFuncNamePrefix}contains";

    public static string EqualsOrContains => $"{JsInteropFuncNamePrefix}equalsOrContains";

    public static string Copy => $"{JsInteropFuncNamePrefix}copy";

    public static string Log => $"{JsInteropFuncNamePrefix}log";

    public static string Focus => $"{JsInteropFuncNamePrefix}focus";

    public static string Select => $"{JsInteropFuncNamePrefix}select";

    public static string HasFocus => $"{JsInteropFuncNamePrefix}hasFocus";

    public static string Blur => $"{JsInteropFuncNamePrefix}blur";

    public static string ScrollTo => $"{JsInteropFuncNamePrefix}scrollTo";

    public static string ScrollToTarget => $"{JsInteropFuncNamePrefix}scrollToTarget";

    public static string ScrollIntoView => $"{JsInteropFuncNamePrefix}scrollIntoView";

    public static string ScrollToElement => $"{JsInteropFuncNamePrefix}scrollToElement";

    public static string ScrollIntoParentView => $"{JsInteropFuncNamePrefix}scrollIntoParentView";

    public static string ScrollToActiveElement => $"{JsInteropFuncNamePrefix}scrollToActiveElement";

    public static string AddCls => $"{JsInteropFuncNamePrefix}addCls";

    public static string AddClsToFirstChild => $"{JsInteropFuncNamePrefix}addClsToFirstChild";

    public static string RemoveCls => $"{JsInteropFuncNamePrefix}removeCls";

    public static string RemoveClsFromFirstChild => $"{JsInteropFuncNamePrefix}removeClsFromFirstChild";

    public static string AddElementToBody => $"{JsInteropFuncNamePrefix}addElementToBody";

    public static string DelElementFromBody => $"{JsInteropFuncNamePrefix}delElementFromBody";

    public static string AddElementTo => $"{JsInteropFuncNamePrefix}addElementTo";

    public static string DelElementFrom => $"{JsInteropFuncNamePrefix}delElementFrom";

    public static string GetActiveElement => $"{JsInteropFuncNamePrefix}getActiveElement";

    public static string FocusDialog => $"{JsInteropFuncNamePrefix}focusDialog";

    public static string GetWindow => $"{JsInteropFuncNamePrefix}getWindow";

    public static string GetWindowAndDocumentProps => $"{JsInteropFuncNamePrefix}getWindowAndDocumentProps";

    public static string GetScroll => $"{JsInteropFuncNamePrefix}getScroll";

    public static string GetInnerText => $"{JsInteropFuncNamePrefix}getInnerText";

    public static string GetMaxZIndex => $"{JsInteropFuncNamePrefix}getMaxZIndex";

    public static string DisposeObj => $"{JsInteropFuncNamePrefix}disposeObj";

    public static string ElementScrollIntoView => $"{JsInteropFuncNamePrefix}elementScrollIntoView";

    public static string GetStyle => $"{JsInteropFuncNamePrefix}getStyle";

    public static string RegisterTextFieldOnMouseDown => $"{JsInteropFuncNamePrefix}registerTextFieldOnMouseDown";

    public static string UnregisterTextFieldOnMouseDown => $"{JsInteropFuncNamePrefix}unregisterTextFieldOnMouseDown";

    public static string UpsertThemeStyle => $"{JsInteropFuncNamePrefix}upsertThemeStyle";

    public static string GetImageDimensions => $"{JsInteropFuncNamePrefix}getImageDimensions";

    internal static string PreventDefaultForSpecificKeys => $"{JsInteropFuncNamePrefix}preventDefaultForSpecificKeys";
    
    public static string GetBoundingClientRects => $"{JsInteropFuncNamePrefix}getBoundingClientRects";

    public static string GetSize => $"{JsInteropFuncNamePrefix}getSize";

    public static string GetProp => $"{JsInteropFuncNamePrefix}getProp";

    public static string IsMobile => $"{JsInteropFuncNamePrefix}isMobile";

    public static string SetStyle => $"{JsInteropFuncNamePrefix}css";

    public static string GetZIndex => $"{JsInteropFuncNamePrefix}getZIndex";

    public static string GetMenuOrDialogMaxZIndex => $"{JsInteropFuncNamePrefix}getMenuOrDialogMaxZIndex";

    public static string ContainsActiveElement => $"{JsInteropFuncNamePrefix}containsActiveElement";

    public static string RegisterOTPInputOnInputEvent => $"{JsInteropFuncNamePrefix}registerOTPInputOnInputEvent";

    public static string UnregisterOTPInputOnInputEvent => $"{JsInteropFuncNamePrefix}unregisterOTPInputOnInputEvent";

    public static string CopyChild => $"{JsInteropFuncNamePrefix}copyChild";

    public static string CopyText => $"{JsInteropFuncNamePrefix}copyText";

    public static string GetListIndexWhereAttributeExists => $"{JsInteropFuncNamePrefix}getListIndexWhereAttributeExists";

    public static string ScrollToTile => $"{JsInteropFuncNamePrefix}scrollToTile";

    public static string GetElementTranslateY => $"{JsInteropFuncNamePrefix}getElementTranslateY";

    internal static string RegisterInfiniteScrollJSInterop => $"{JsInteropFuncNamePrefix}registerInfiniteScrollJSInterop";

    public static string SetProperty => $"{JsInteropFuncNamePrefix}setProperty";

    public static string UpdateWindowTransition => $"{JsInteropFuncNamePrefix}updateWindowTransition";

    internal static string InvokeMultipleMethod => $"{JsInteropFuncNamePrefix}invokeMultipleMethod";

    public static string SetCookie => $"{JsInteropFuncNamePrefix}setCookie";

    public static string GetCookie => $"{JsInteropFuncNamePrefix}getCookie";

    public static string ResizableDataTable => $"{JsInteropFuncNamePrefix}resizableDataTable";

    public static string UpdateDataTableResizeHeight => $"{JsInteropFuncNamePrefix}updateDataTableResizeHeight";

    public static string RegisterDragEvent => $"{JsInteropFuncNamePrefix}registerDragEvent";

    public static string UnregisterDragEvent => $"{JsInteropFuncNamePrefix}unregisterDragEvent";

    public static string RegisterSliderEvents => $"{JsInteropFuncNamePrefix}registerSliderEvents";

    public static string UnregisterSliderEvents => $"{JsInteropFuncNamePrefix}unregisterSliderEvents";

    public static string AddStopPropagationEvent => $"{JsInteropFuncNamePrefix}addStopPropagationEvent";

    public static string RemoveStopPropagationEvent => $"{JsInteropFuncNamePrefix}removeStopPropagationEvent";
        
    public static string HistoryBack => $"{JsInteropFuncNamePrefix}historyBack";

    public static string HistoryGo => $"{JsInteropFuncNamePrefix}historyGo";

    public static string HistoryReplace => $"{JsInteropFuncNamePrefix}historyReplace";
    
    internal static string RegisterTextareaAutoGrowEvent => $"{JsInteropFuncNamePrefix}registerTextareaAutoGrowEvent";
    
    internal static string UnregisterTextareaAutoGrowEvent => $"{JsInteropFuncNamePrefix}unregisterTextareaAutoGrowEvent";
    
    internal static string CalculateTextareaHeight => $"{JsInteropFuncNamePrefix}calculateTextareaHeight";

    internal static string RegisterTableScrollEvent => $"{JsInteropFuncNamePrefix}registerTableScrollEvent";

    internal static string UnregisterTableScrollEvent => $"{JsInteropFuncNamePrefix}unregisterTableScrollEvent";

    internal static string UpdateTabSlider => $"{JsInteropFuncNamePrefix}updateTabSlider";

    /// <summary>
    /// Check if the scroll is near the bottom of the element.
    /// Arguments: element, threshold
    /// </summary>
    public static string IsScrollNearBottom => $"{JsInteropFuncNamePrefix}isScrollNearBottom";

    public static string MatchesSelector => $"{JsInteropFuncNamePrefix}matchesSelector";
    
    public static string prepareSticky => $"{JsInteropFuncNamePrefix}prepareSticky";

    public static string ToggleMourningMode => $"{JsInteropFuncNamePrefix}toggleMourningMode";
}