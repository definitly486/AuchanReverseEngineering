package com.google.android.play.core.integrity;

import android.content.Context;

/* JADX INFO: compiled from: com.google.android.play:integrity@@1.1.0 */
/* JADX INFO: loaded from: classes2.dex */
final class l {
    private static j a;

    static synchronized j a(Context context) {
        try {
            if (a == null) {
                h hVar = new h(null);
                Context applicationContext = context.getApplicationContext();
                if (applicationContext != null) {
                    context = applicationContext;
                }
                hVar.a(context);
                a = hVar.b();
            }
        } catch (Throwable th) {
            throw th;
        }
        return a;
    }
}
