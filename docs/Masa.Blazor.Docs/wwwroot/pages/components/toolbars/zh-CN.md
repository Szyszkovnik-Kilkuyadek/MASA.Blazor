---
title: Toolbars（工具栏）
desc: "**MToolbar** 组件对于任何 GUI 都是至关重要的，因为它通常是站点导航的主要来源。 工具栏组件与 [MNavigationDrawer](/blazor/components/navigation-drawers) 和 [MCard](/blazor/components/cards) 配合使用非常有效。"
related:
  - /blazor/components/buttons
  - /blazor/components/footers
  - /blazor/components/tabs
---

## 使用

工具栏是一个灵活的容器，可以通过多种方式使用。 默认情况下，工具栏在桌面上是64px高，在移动设备上是56px高。 有许多辅助组件可供工具栏使用。 **MToolbarTitle** 用于显示标题并且 **MToolbarItems** 允许 **MButton** 扩展全高度。

<toolbars-usage></toolbars-usage>

## 组件结构解剖

## 注意

<app-alert type="warning" content="当在 **MToolbar** 和 **MAppBar** 内部使用带有 `Icon` 属性的 **MButton** 时，它们将自动增大其尺寸并应用负边距，以确保根据Material设计规范的适当间距。
如果您选择将您的按钮包装在任何容器中，例如 `div`， 您需要对容器应用负边距，以便正确对齐。"></app-alert>

## 示例

### 属性

#### 背景

工具栏可以使用 `Src` 属性显示背景而不是纯色。 这可以通过使用 `Img` 插槽并提供您自己的 [MImage](/blazor/components/images) 组件来修改。
可以使用 [MAppBar](/blazor/components/app-bars) 使背景淡入淡出

<masa-example file="Examples.components.toolbars.Background"></masa-example>

#### 折叠

可以折叠工具栏以节省屏幕空间。

<masa-example file="Examples.components.toolbars.Collapse"></masa-example>

#### 紧凑工具栏

紧凑工具栏将其高度降低到 48px。 当与 `Prominent` 属性同时使用时，高度将会降低到 96px。

<masa-example file="Examples.components.toolbars.DenseToolbars"></masa-example>

#### 扩展

工具栏可以在不使用扩展插槽的情况下扩展。

<masa-example file="Examples.components.toolbars.Extended"></masa-example>

#### 扩展高度

扩展的高度可以定制。

<masa-example file="Examples.components.toolbars.ExtensitionHeight"></masa-example>

#### 搜索时浮动

浮动工具栏变成内联元素，只占用所需空间的。 将工具栏放置在内容上时这将特别有用。

<masa-example file="Examples.components.toolbars.FloatingWithSearch"></masa-example>

#### 浅色和深色

工具栏有 2 种变体，浅色和深色。 浅色工具栏具有深色按钮和深色文本，而深色工具栏具有白色按钮和白色文本。

<masa-example file="Examples.components.toolbars.LightAndDark"></masa-example>

#### 突出的工具栏

突出的工具栏将 **MToolbar** 的高度增加到 128px ，并将 **MToolbarTitle** 放置到容器底部。 
在 **MApp** 中扩展了这个功能，能够将突出的工具栏缩小为密集或短工具栏。

<masa-example file="Examples.components.toolbars.ProminentToolbars"></masa-example>

### 其他

#### 上下文操作栏

可以更新工具栏的外观以响应应用程序状态的改变。 在本例中，工具栏的颜色和内容会随着用户在 **MSelect** 中的选择而改变。

<masa-example file="Examples.components.toolbars.ContextualActionBar"></masa-example>

#### 灵活的卡片工具栏

在本例中，我们使用 `Extended` 属性将卡片偏移到工具栏的扩展内容区域。

<masa-example file="Examples.components.toolbars.FlexibleAndCardToolbar"></masa-example>
