package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.networktasks.internal.BaseRequestConfig;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.d6, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public class C0198d6 extends BaseRequestConfig {
    public String a;
    public String b;
    public C0706wm c;

    public final String b() {
        return this.b;
    }

    @Override // io.appmetrica.analytics.networktasks.internal.BaseRequestConfig
    public String toString() {
        return "CoreRequestConfig{mAppDebuggable='" + this.a + "', mAppSystem='" + this.b + "', startupState=" + this.c + '}';
    }

    public final String a() {
        return this.a;
    }
}
