package io.appmetrica.analytics.impl;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import java.io.Closeable;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.vc, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0670vc implements Q6 {
    public final Context a;
    public final String b;
    public final C0759yn c;
    public final C0642ua d;
    public C0509p7 e;

    public C0670vc(Context context, String str, C0759yn c0759yn) {
        this(context, str, new C0642ua(str), c0759yn);
    }

    @Override // io.appmetrica.analytics.impl.Q6
    public final synchronized SQLiteDatabase a() {
        C0509p7 c0509p7;
        try {
            this.d.a();
            c0509p7 = new C0509p7(this.a, this.b, this.c, PublicLogger.getAnonymousInstance());
            this.e = c0509p7;
        } catch (Throwable unused) {
            return null;
        }
        return c0509p7.getWritableDatabase();
    }

    public C0670vc(Context context, String str, C0642ua c0642ua, C0759yn c0759yn) {
        this.a = context;
        this.b = str;
        this.d = c0642ua;
        this.c = c0759yn;
    }

    @Override // io.appmetrica.analytics.impl.Q6
    public final synchronized void a(SQLiteDatabase sQLiteDatabase) {
        if (sQLiteDatabase != null) {
            try {
                sQLiteDatabase.close();
            } catch (Throwable unused) {
            }
        }
        Do.a((Closeable) this.e);
        this.d.b();
        this.e = null;
    }
}
