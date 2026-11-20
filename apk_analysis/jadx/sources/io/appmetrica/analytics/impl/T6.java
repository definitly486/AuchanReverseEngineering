package io.appmetrica.analytics.impl;

import android.os.Bundle;
import android.os.Handler;
import android.os.ResultReceiver;

/* JADX INFO: loaded from: classes3.dex */
public final class T6 extends ResultReceiver {
    public final S6 a;

    public T6(Handler handler, S6 s6) {
        super(handler);
        this.a = s6;
    }

    public static void a(ResultReceiver resultReceiver, C0350j4 c0350j4) {
        if (resultReceiver != null) {
            Bundle bundle = new Bundle();
            c0350j4.b(bundle);
            resultReceiver.send(1, bundle);
        }
    }

    @Override // android.os.ResultReceiver
    public final void onReceiveResult(int i, Bundle bundle) {
        if (bundle == null) {
            bundle = new Bundle();
        }
        this.a.a(i, bundle);
    }

    public static void a(ResultReceiver resultReceiver, EnumC0136am enumC0136am, C0350j4 c0350j4) {
        if (resultReceiver != null) {
            Bundle bundle = new Bundle();
            bundle.putInt("startup_error_key_code", enumC0136am.a);
            c0350j4.b(bundle);
            resultReceiver.send(2, bundle);
        }
    }
}
