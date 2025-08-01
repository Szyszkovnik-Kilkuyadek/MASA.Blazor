---
title: Progress circular（进度环）
desc: "该组件用于向用户展示环形的数据。 它也可以设置为不确定的状态来表示加载。"
related:
  - /blazor/components/progress-linear
  - /blazor/components/popup-service
---

> 可以通过 [IPopupService](/blazor/components/popup-service#progress) 封装的方法实现全局加载效果。

## 使用

**MProgressCircular** 以其最简单的形式显示圆形进度条。使用 `value` 属性控制进度。

<progress-circular-usage></progress-circular-usage>

## 示例

### 属性

#### 颜色

可以使用 `Color` 属性为 **MProgressCircular** 设置其他颜色。

<masa-example file="Examples.components.progress_circular.Color"></masa-example>

#### 不定线条

使用 `Indeterminate` 属性，**MProgressCircular** 将会一直处于动画中。

<masa-example file="Examples.components.progress_circular.Indeterminate"></masa-example>

#### 旋转

`Rotate` 参数使您能够自定义 **MProgressCircular** 的原点。

<masa-example file="Examples.components.progress_circular.Rotate"></masa-example>

#### 大小和宽度

`Size` 和 `Width` 属性允许您轻松修改 **MProgressCircular** 组件的大小和宽度。

<masa-example file="Examples.components.progress_circular.SizeOrWidth"></masa-example>
