package io.appmetrica.analytics.impl;

import android.content.Context;
import com.android.installreferrer.api.InstallReferrerClient;
import io.appmetrica.analytics.coreapi.internal.executors.ICommonExecutor;
import io.appmetrica.analytics.coreutils.internal.reflection.ReflectionUtils;

/* JADX INFO: loaded from: classes3.dex */
public final class Na implements Bg {
    public final Context a;
    public final ICommonExecutor b;
    public final String c = "google";

    public Na(Context context, ICommonExecutor iCommonExecutor) {
        this.a = context;
        this.b = iCommonExecutor;
    }

    @Override // io.appmetrica.analytics.impl.Bg
    public final String a() {
        return this.c;
    }

    @Override // io.appmetrica.analytics.impl.Bg
    public final void a(InterfaceC0726xg interfaceC0726xg) {
        if (!ReflectionUtils.detectClassExists("com.android.installreferrer.api.InstallReferrerClient")) {
            interfaceC0726xg.a(new Cg("Google Play Install Referrer library is not detected", null, 2, null));
            return;
        }
        Ma ma = new Ma(this.b);
        try {
            InstallReferrerClient installReferrerClientBuild = InstallReferrerClient.newBuilder(this.a).build();
            installReferrerClientBuild.startConnection(new La(ma, installReferrerClientBuild, interfaceC0726xg));
        } catch (Throwable th) {
            C0263fk c0263fk = Dj.a;
            c0263fk.getClass();
            c0263fk.a(new Ej("Failed to get referrer from Google Play referrer library", th));
            interfaceC0726xg.a(new Cg("Failed to get referrer from Google Play referrer library", th));
        }
    }
}
