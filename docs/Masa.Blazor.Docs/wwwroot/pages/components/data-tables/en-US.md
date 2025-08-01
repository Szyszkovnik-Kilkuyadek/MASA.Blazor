---
title: Data tables
desc: "The MDataTable component is used for displaying tabular data. Features include sorting, searching, pagination, content-editing, and row selection."
related:
  - /blazor/components/data-iterators
  - /blazor/components/simple-tables
  - /blazor/components/lists
---

## Usage

The standard data-table will by default render your data as simple rows.

<masa-example file="Examples.components.data_tables.Usage"></masa-example>

## Examples

### Props

#### ValueExpression {released-on=v1.11.0}

The `DataTableHeader<TItem>.ValueExpression` property allows you to specify an expression to get the value of the data table. This is useful when working with complex objects in your data table.

<masa-example file="Examples.components.data_tables.ValueExpression"></masa-example>

#### Cell ellipsis {released-on=v1.5.0}

Setting the `Width` property on a cell and enabling the `Ellipsis` property will show an ellipsis when the cell content overflows.

<masa-example file="Examples.components.data_tables.Ellipsis"></masa-example>

#### Custom cell {released-on=v1.5.0}

In addition to using the `ItemColContent` slot to customize cell content, you can also use the `CellRender` prop.

<masa-example file="Examples.components.data_tables.CellRender"></masa-example>

#### CustomFilter

You can override the default filtering used with `Search` prop by supplying a function to the `CustomFilter` prop. If you
need to customize the filtering of a specific column, you can supply a function to the `Filter` property on header items.
The signature is `Func<object, string, TItem, bool>`. This function will always be run even if
`Search` prop has not been provided. Thus you need to make sure to exit early with a value of true if filter should not be
applied.

<masa-example file="Examples.components.data_tables.CustomFilter"></masa-example>

#### Dense

Using the `Dense` prop you are able to give your data tables an alternate style.

<masa-example file="Examples.components.data_tables.Dense"></masa-example>

#### Filterable

You can easily disable specific columns from being included when searching through table rows by setting the property `Filterable` to false on the header item(s). In the example below the dessert name column is no longer searchable.

<masa-example file="Examples.components.data_tables.Filterable"></masa-example>

#### Footer

The **MDataTable** renders a default footer using the **MDataFooter**  component. You can pass props to this component using `FooterProps`.

<masa-example file="Examples.components.data_tables.Footer"></masa-example>

#### Group

Using the `GroupBy` and `GroupDesc` props you can group rows on an item property. The `ShowGroupBy` prop will show a group
button in the default header. You can use the `Groupable` property on header items to disable the group button.

<masa-example file="Examples.components.data_tables.Group"></masa-example>

#### Hide default header and footer

You can apply the `HideDefaultHeader` and `HideDefaultFooter` props to remove the default header and footer
respectively.

<masa-example file="Examples.components.data_tables.HideDefaultHeaderAndFooter"></masa-example>

#### Loading

You can use the `Loading` prop to indicate that data in the table is currently loading. If there is no data in the
table, a loading message will also be displayed. This message can be customized using the `LoadingText` prop or the
`LoadingContent` slot.

<masa-example file="Examples.components.data_tables.Loading"></masa-example>

#### Multi sort

Using the `MultiSort` prop will enable you to sort on multiple columns at the same time. When enabled, you can pass
arrays to both `SortBy` and `SortDesc` to programmatically control the sorting, instead of single values.

<masa-example file="Examples.components.data_tables.MultiSort"></masa-example>

#### ShowSelect {updated-in=v1.7.0}

The `ShowSelect` prop will render a checkbox in the default header to toggle all rows, and a checkbox for each default
row. You can also switch between allowing multiple selected rows at the same time or just one with the `SingleSelect` prop.
The `ItemKey` prop is used to specify a unique identifier for rows, which is used for row selection.

> In version 1.7.0, the `@bind-Selected` usage was added to replace `@bind-Value`, making it easier to set the default selected rows.

<masa-example file="Examples.components.data_tables.RowSelection"></masa-example>

#### Search

The data table exposes a `Search` prop that allows you to filter your data.

<masa-example file="Examples.components.data_tables.Search"></masa-example>

#### Fixed {released-on=v1.2.0}

Fixed columns using the `Fixed` prop in the **Headers** array.

<masa-example file="Examples.components.data_tables.Fixed"></masa-example>

#### Stripe

Striped table.

<masa-example file="Examples.components.data_tables.Stripe"></masa-example>

#### Resize mode {released-on=v1.0.4}

Using the `ResizeMode` prop you can allow users to resize columns.

<masa-example file="Examples.components.data_tables.ResizeMode"></masa-example>

### Contents

#### Header

You can use the dynamic slots **HeaderColContent** to customize only certain columns.

<masa-example file="Examples.components.data_tables.Header"></masa-example>

#### Cell content

You can use the dynamic slots **ItemColContent** to customize only certain columns.

<masa-example file="Examples.components.data_tables.Item"></masa-example>

#### Simple checkbox

When wanting to use a checkbox component inside of a slot template in your data tables, use the **MSimpleCheckbox**
component rather than the **MCheckbox** component. The **MSimplleChecbox** component is used internally and will respect
header alignment.

<masa-example file="Examples.components.data_tables.SimpleCheckbox"></masa-example>

### Misc

#### CRUD Actions

**MDataTable** with CRUD actions using a **MDialog** component for editing each row.

<masa-example file="Examples.components.data_tables.CRUDActions"></masa-example>

#### ExpandableRow

The `ShowExpand`  prop will render an expand icon on each default row. You can customize this with the
**ItemDataTableExpandContent** slot. The position of this slot can be customized by adding a column
with `Value="data-table-expand"` to the **Headers** array. You can also switch between allowing multiple expanded rows
at the same time or just one with the `SingleExpand` prop. Row items require a unique key property for expansion to
work, use **ItemKey** prop to specify.

<masa-example file="Examples.components.data_tables.ExpandableRow"></masa-example>

#### External pagination

Pagination can be controlled externally by using the individual props, or by using the `Options` prop.

<masa-example file="Examples.components.data_tables.ExternalPagination"></masa-example>

#### External sorting

Sorting can also be controlled externally by using the individual props, or by using the `Options` prop.

<masa-example file="Examples.components.data_tables.ExternalSorting"></masa-example>

#### Server-side paginate and sort

If you’re loading data already paginated and sorted from a backend, you can use the `ServerItemsLength` prop. Defining
this prop will disable the built-in sorting and pagination, and you will instead need to use the `OnOptionsUpdate` event to know when to request new pages from your backend. Use
the `Loading` prop to display a progress bar while fetching data.

<masa-example file="Examples.components.data_tables.ServerSidePaginateAndSort"></masa-example>

#### Editable cells {released-on=v1.6.0}

Apply the `editable-cell` class to a cell to optimize the input box style.

<masa-example file="Examples.components.data_tables.EditableCells"></masa-example>
