namespace System;

public delegate void EventHandler(object? sender, EventArgs e);
public delegate void EventHandler<in TEventArgs>(object? sender, TEventArgs e);
public delegate void EventHandler<in TSender, in TEventArgs>(TSender sender, TEventArgs e);
