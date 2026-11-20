package io.appmetrica.analytics.impl;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import io.appmetrica.analytics.coreapi.internal.data.ProtobufStateStorage;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;

/* JADX INFO: loaded from: classes3.dex */
public final class Jk implements InterfaceC0205dd {
    public static final boolean a(SQLiteDatabase sQLiteDatabase) {
        return true;
    }

    public static void b(Context context) {
        C0509p7 c0509p7;
        Ik ik = new Ik();
        Hk hk = new Hk();
        C0759yn c0759yn = new C0759yn(hk, hk, new Pa(false), new InterfaceC0785zn() { // from class: io.appmetrica.analytics.impl.Jk$$ExternalSyntheticLambda0
            @Override // io.appmetrica.analytics.impl.InterfaceC0785zn
            public final boolean a(SQLiteDatabase sQLiteDatabase) {
                return Jk.a(sQLiteDatabase);
            }
        });
        Pk pkB = Ka.I.B();
        synchronized (pkB) {
            C0561r7 c0561r7 = pkB.a;
            c0509p7 = new C0509p7(context, new C0536q7(c0561r7.a, c0561r7.b, false).a(context, ik), c0759yn, PublicLogger.getAnonymousInstance());
        }
        byte[] bArr = new C0246f3(new Kl(c0509p7), "binary_data").get("auto_inapp_collecting_info_data");
        if (bArr != null) {
            Ka.I.B().c(context).insert("auto_inapp_collecting_info_data", bArr);
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0205dd
    public final void a(Context context) {
        AbstractC0343in abstractC0343in = (AbstractC0343in) C0292gn.a(Am.class);
        ProtobufStateStorage<Object> protobufStateStorageA = abstractC0343in.a(context, abstractC0343in.b(context));
        Am am = (Am) protobufStateStorageA.read();
        C0784zm c0784zmA = am.a(am.m);
        c0784zmA.o = 0L;
        protobufStateStorageA.save(new Am(c0784zmA));
        b(context);
    }
}
