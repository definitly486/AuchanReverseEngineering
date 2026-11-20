package io.appmetrica.analytics.impl;

import android.content.Context;
import android.database.Cursor;
import android.net.Uri;
import com.scanflow.datacapture.barinternal.kotlin.io.CloseableKt;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import io.appmetrica.analytics.coreapi.internal.executors.InterruptionSafeThread;

/* JADX INFO: loaded from: classes3.dex */
public final class Ya implements Bg {
    public final Context a;
    public final String b = "huawei";

    public Ya(Context context) {
        this.a = context;
    }

    @Override // io.appmetrica.analytics.impl.Bg
    public final String a() {
        return this.b;
    }

    public static final void a(InterfaceC0726xg interfaceC0726xg, Ya ya) {
        Eg cg;
        Context context = ya.a;
        try {
            Cursor cursorQuery = context.getContentResolver().query(Uri.parse("content://com.huawei.appmarket.commondata/item/5"), null, null, new String[]{context.getPackageName()}, null);
            if (cursorQuery == null) {
                throw new IllegalStateException("Not found content provider");
            }
            try {
                if (!cursorQuery.moveToFirst()) {
                    throw new IllegalStateException("Cursor is empty");
                }
                String string = cursorQuery.getString(0);
                if (string == null || StringsKt.isBlank(string)) {
                    throw new IllegalStateException("Referrer is empty");
                }
                cg = new Dg(new C0674vg(string, cursorQuery.getLong(1), cursorQuery.getLong(2), 3));
                CloseableKt.closeFinally(cursorQuery, null);
                interfaceC0726xg.a(cg);
            } catch (Throwable th) {
                try {
                    throw th;
                } catch (Throwable th2) {
                    CloseableKt.closeFinally(cursorQuery, th);
                    throw th2;
                }
            }
        } catch (Throwable th3) {
            cg = new Cg("Failed to get referrer from huawei content provider", th3);
        }
    }

    @Override // io.appmetrica.analytics.impl.Bg
    public final void a(final InterfaceC0726xg interfaceC0726xg) {
        Bk bk = Ka.I.d;
        Runnable runnable = new Runnable() { // from class: io.appmetrica.analytics.impl.Ya$$ExternalSyntheticLambda0
            @Override // java.lang.Runnable
            public final void run() {
                Ya.a(interfaceC0726xg, this);
            }
        };
        bk.a.getClass();
        new InterruptionSafeThread(runnable, "IAA-SHMSR-" + Td.a.incrementAndGet()).start();
    }
}
