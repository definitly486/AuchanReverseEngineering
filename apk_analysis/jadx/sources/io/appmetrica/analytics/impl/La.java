package io.appmetrica.analytics.impl;

import com.android.installreferrer.api.InstallReferrerClient;
import com.android.installreferrer.api.InstallReferrerStateListener;
import com.android.installreferrer.api.ReferrerDetails;
import com.scanflow.datacapture.barinternal.kotlin.Result;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;

/* JADX INFO: loaded from: classes3.dex */
public final class La implements InstallReferrerStateListener {
    public final InstallReferrerClient a;
    public final InterfaceC0726xg b;
    public final /* synthetic */ Ma c;

    public La(Ma ma, InstallReferrerClient installReferrerClient, InterfaceC0726xg interfaceC0726xg) {
        this.c = ma;
        this.a = installReferrerClient;
        this.b = interfaceC0726xg;
    }

    public static void a(int i) {
        if (i == 3) {
            C0263fk c0263fk = Dj.a;
            IllegalStateException illegalStateException = new IllegalStateException("Developer error");
            c0263fk.getClass();
            c0263fk.a(new Ej("Failed to get referrer via Google Play referrer library", illegalStateException));
            return;
        }
        if (i != 4) {
            return;
        }
        C0263fk c0263fk2 = Dj.a;
        IllegalStateException illegalStateException2 = new IllegalStateException("Permission error");
        c0263fk2.getClass();
        c0263fk2.a(new Ej("Failed to get referrer via Google Play referrer library", illegalStateException2));
    }

    @Override // com.android.installreferrer.api.InstallReferrerStateListener
    public final void onInstallReferrerServiceDisconnected() {
    }

    @Override // com.android.installreferrer.api.InstallReferrerStateListener
    public final void onInstallReferrerSetupFinished(final int i) {
        this.c.a.execute(new Runnable() { // from class: io.appmetrica.analytics.impl.La$$ExternalSyntheticLambda0
            @Override // java.lang.Runnable
            public final void run() {
                La.a(this.f$0, i);
            }
        });
    }

    public static final void a(La la, int i) {
        Object objM681constructorimpl;
        String installReferrer;
        Object dg;
        try {
            Result.Companion companion = Result.Companion;
            if (i != 0) {
                la.getClass();
                a(i);
                dg = new Cg("The connection returned an error code " + i, null, 2, null);
            } else {
                ReferrerDetails installReferrer2 = la.a.getInstallReferrer();
                C0674vg c0674vg = (installReferrer2 == null || (installReferrer = installReferrer2.getInstallReferrer()) == null || StringsKt.isBlank(installReferrer)) ? null : new C0674vg(installReferrer2.getInstallReferrer(), installReferrer2.getReferrerClickTimestampSeconds(), installReferrer2.getInstallBeginTimestampSeconds(), 2);
                if (c0674vg == null) {
                    dg = new Cg("Referrer is null", null, 2, null);
                } else {
                    dg = new Dg(c0674vg);
                }
            }
            objM681constructorimpl = Result.m681constructorimpl(dg);
        } catch (Throwable th) {
            Result.Companion companion2 = Result.Companion;
            objM681constructorimpl = Result.m681constructorimpl(ResultKt.createFailure(th));
        }
        Throwable thM683exceptionOrNullimpl = Result.m683exceptionOrNullimpl(objM681constructorimpl);
        if (thM683exceptionOrNullimpl != null) {
            C0263fk c0263fk = Dj.a;
            c0263fk.getClass();
            c0263fk.a(new Ej("Failed to get referrer via Google Play referrer library", thM683exceptionOrNullimpl));
            objM681constructorimpl = new Cg("Failed to get referrer via Google Play referrer library", thM683exceptionOrNullimpl);
        }
        Eg eg = (Eg) objM681constructorimpl;
        try {
            la.a.endConnection();
        } catch (Throwable unused) {
        }
        la.b.a(eg);
    }
}
