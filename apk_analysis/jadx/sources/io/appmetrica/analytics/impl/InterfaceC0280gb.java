package io.appmetrica.analytics.impl;

import java.util.Set;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.gb, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public interface InterfaceC0280gb {
    InterfaceC0280gb a(String str, float f);

    InterfaceC0280gb a(String str, int i);

    InterfaceC0280gb a(String str, long j);

    InterfaceC0280gb a(String str, String str2);

    InterfaceC0280gb a(String str, boolean z);

    void a();

    boolean a(String str);

    Set b();

    void flushAsync();

    boolean getBoolean(String str, boolean z);

    int getInt(String str, int i);

    long getLong(String str, long j);

    String getString(String str, String str2);

    InterfaceC0280gb remove(String str);
}
