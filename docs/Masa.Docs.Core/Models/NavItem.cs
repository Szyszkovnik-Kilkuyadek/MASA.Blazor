﻿namespace Masa.Docs.Core.Models;

public class NavItem : IDefaultItem<NavItem>
{
    public NavItem()
    {
    }

    public NavItem(string title)
    {
        Title = title;
    }

    public string? Title { get; set; }

    public StringNumber Value { get; set; }

    public List<NavItem>? Children { get; set; }

    public string? Group { get; set; }

    public string? Heading { get; set; }

    public bool Divider { get; set; }

    public string? Href { get; set; }

    public bool Exact { get; set; }

    public string? Icon { get; set; }

    public string? State { get; set; }

    public string? StateBackgroundColor { get; set; }

    public string? ReleasedOn { get; set; }

    public string? Segment => (Group ?? Title);

    public ComponentType ComponentType { get; set; }
}

public enum ComponentType
{
    Unknown,
    Containment,
    Navigation,
    Form,
    DataDisplay,
    Selection,
    Feedback,
    ImagesAndIcons,
    Pickers,
    Providers,
    Services,
    Misc
}