package io.appmetrica.analytics.impl;

import android.app.Activity;
import android.location.Location;
import io.appmetrica.analytics.AnrListener;
import io.appmetrica.analytics.ExternalAttribution;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.hb, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public interface InterfaceC0306hb extends InterfaceC0177cb, InterfaceC0179cd {
    void a(Activity activity);

    @Override // io.appmetrica.analytics.impl.InterfaceC0179cd
    /* synthetic */ void a(Location location);

    void a(AnrListener anrListener);

    void a(ExternalAttribution externalAttribution);

    void a(ap apVar);

    void a(EnumC0449n enumC0449n);

    @Override // io.appmetrica.analytics.impl.InterfaceC0179cd
    /* synthetic */ void a(String str);

    @Override // io.appmetrica.analytics.impl.InterfaceC0179cd
    /* synthetic */ void a(String str, String str2);

    void a(String str, boolean z);

    @Override // io.appmetrica.analytics.impl.InterfaceC0179cd
    /* synthetic */ void a(boolean z);

    @Override // io.appmetrica.analytics.impl.InterfaceC0179cd
    /* synthetic */ void a(boolean z, boolean z2);

    void b(Activity activity);

    @Override // io.appmetrica.analytics.impl.InterfaceC0177cb
    /* synthetic */ void b(String str);

    @Override // io.appmetrica.analytics.impl.InterfaceC0177cb
    /* synthetic */ void b(String str, String str2);

    @Override // io.appmetrica.analytics.impl.InterfaceC0177cb
    /* synthetic */ boolean b();

    void c();

    List<String> f();
}
