package io.appmetrica.analytics.impl;

import android.os.Bundle;
import android.os.Handler;
import android.os.ResultReceiver;

/* JADX INFO: loaded from: classes3.dex */
public final class Fg extends ResultReceiver {
    public final C0622tg a;

    public Fg(Handler handler, C0622tg c0622tg) {
        super(handler);
        this.a = c0622tg;
    }

    public static void a(ResultReceiver resultReceiver, C0674vg c0674vg) {
        if (resultReceiver != null) {
            Bundle bundle = new Bundle();
            bundle.putByteArray("referrer", c0674vg == null ? null : c0674vg.a());
            resultReceiver.send(1, bundle);
        }
    }

    @Override // android.os.ResultReceiver
    public final void onReceiveResult(int i, Bundle bundle) {
        if (i == 1) {
            C0674vg c0674vg = null;
            try {
                byte[] byteArray = bundle.getByteArray("referrer");
                if (byteArray != null && byteArray.length != 0) {
                    c0674vg = new C0674vg(byteArray);
                }
            } catch (Throwable unused) {
            }
            this.a.a(c0674vg);
        }
    }
}
