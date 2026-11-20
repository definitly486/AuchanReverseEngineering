package io.appmetrica.analytics.impl;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.text.TextUtils;
import io.appmetrica.analytics.coreutils.internal.encryption.AESEncrypter;
import io.appmetrica.analytics.coreutils.internal.io.CloseableUtils;
import io.appmetrica.analytics.coreutils.internal.parsing.JsonUtils;
import io.appmetrica.analytics.protobuf.nano.MessageNano;

/* JADX INFO: loaded from: classes3.dex */
public final class Fk implements InterfaceC0205dd {
    public final Oo a;
    public final String b = "startup_state";
    public final AESEncrypter c;

    public Fk(Oo oo) {
        this.a = oo;
        C0113a c0113a = new C0113a(Ka.k().g());
        this.c = new AESEncrypter(AESEncrypter.DEFAULT_ALGORITHM, c0113a.b(), c0113a.a());
    }

    public static void a(Oo oo, C0784zm c0784zm, Wb wb) {
        String strOptStringOrNull;
        synchronized (oo) {
            strOptStringOrNull = JsonUtils.optStringOrNull(oo.a.a(), "device_id");
        }
        if (TextUtils.isEmpty(strOptStringOrNull)) {
            if (!TextUtils.isEmpty(wb.d)) {
                oo.a(wb.d);
            }
            if (!TextUtils.isEmpty(wb.e)) {
                oo.b(wb.e);
            }
            if (TextUtils.isEmpty(wb.a)) {
                return;
            }
            c0784zm.a = wb.a;
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0205dd
    public final void a(Context context) {
        SQLiteDatabase readableDatabase = Ka.I.B().f(context).getReadableDatabase();
        if (readableDatabase != null) {
            try {
                Wb wbA = a(readableDatabase);
                C0784zm c0784zm = new C0784zm(new C4(new A4()));
                if (wbA != null) {
                    a(this.a, c0784zm, wbA);
                    c0784zm.p = wbA.c;
                    c0784zm.r = wbA.b;
                }
                Am am = new Am(c0784zm);
                AbstractC0343in abstractC0343in = (AbstractC0343in) C0292gn.a(Am.class);
                abstractC0343in.a(context, abstractC0343in.b(context)).save(am);
            } catch (Throwable unused) {
            }
        }
    }

    /* JADX WARN: Code duplicated, block: B:13:0x0047 A[Catch: all -> 0x004c, TRY_ENTER, TRY_LEAVE, TryCatch #1 {all -> 0x004c, blocks: (B:5:0x001b, B:7:0x0022, B:9:0x0028, B:13:0x0047), top: B:21:0x001b }] */
    public final Wb a(SQLiteDatabase sQLiteDatabase) {
        Cursor cursorQuery;
        try {
            cursorQuery = sQLiteDatabase.query("binary_data", new String[]{"value"}, "data_key = ?", new String[]{this.b}, null, null, null);
            if (cursorQuery != null) {
                try {
                    if (cursorQuery.getCount() == 1 && cursorQuery.moveToFirst()) {
                        Wb wb = (Wb) MessageNano.mergeFrom(new Wb(), this.c.decrypt(cursorQuery.getBlob(cursorQuery.getColumnIndexOrThrow("value"))));
                        CloseableUtils.closeSafely(cursorQuery);
                        return wb;
                    }
                    if (cursorQuery != null) {
                        cursorQuery.getCount();
                    }
                } catch (Throwable unused) {
                }
            } else if (cursorQuery != null) {
                cursorQuery.getCount();
            }
        } catch (Throwable unused2) {
            cursorQuery = null;
        }
        CloseableUtils.closeSafely(cursorQuery);
        return null;
    }
}
