﻿---
title: Tour（引导）
desc: "一个基于 [driver.js](https://github.com/kamranahmedse/driver.js) 的引导组件。"
tag: "基于JS封装"
release: v1.9.0
---

```shell {#install-cli}
dotnet add package Masa.Blazor.JSComponents.DriverJS
```

```html {#install-style}
<link href="_content/Masa.Blazor.JSComponents.DriverJS/driver.css" rel="stylesheet"/>
```

## 使用 {#usage}

<masa-example file="Examples.components.driverjs.Usage"></masa-example>

## 示例 {#examples}

### 属性 {#props}

#### 关闭动画 {#no-animation}

<masa-example file="Examples.components.driverjs.NoAnimation"></masa-example>

#### 样式 {#style}

<masa-example file="Examples.components.driverjs.Style"></masa-example>

#### 高亮 {#highlight}

<masa-example file="Examples.components.driverjs.Highlight"></masa-example>

#### 不指定元素 {#no-element}

<masa-example file="Examples.components.driverjs.NoElement"></masa-example>

#### 点击遮罩 {#click-overlay}

默认情况下，点击遮罩会关闭引导。设置 `OverlayClickBehavior` 为 `OverlayClickBehavior.NextStep` 可以在点击遮罩时跳转到下一个步骤。

<masa-example file="Examples.components.driverjs.ClickOverlay"></masa-example>