package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreapi.internal.identifiers.IdentifierStatus;
import io.appmetrica.analytics.coreutils.internal.io.FileUtils;
import io.appmetrica.analytics.internal.IdentifiersResult;

/* JADX INFO: loaded from: classes3.dex */
public final class Pd {
    public final Context a;
    public final InterfaceC0357jb b;
    public final R9 c;
    public final Ve d;
    public final Ho e;
    public volatile IdentifiersResult f;

    public Pd(Context context, InterfaceC0357jb interfaceC0357jb) {
        this(context, interfaceC0357jb, Qd.a(context), new Ve(context), new Ho());
    }

    /* JADX WARN: Code duplicated, block: B:17:0x003d A[Catch: all -> 0x0079, TryCatch #1 {all -> 0x0079, blocks: (B:10:0x0019, B:12:0x0029, B:14:0x002f, B:17:0x003d, B:19:0x0056, B:20:0x0064, B:22:0x006f), top: B:34:0x0019 }] */
    /* JADX WARN: Code duplicated, block: B:19:0x0056 A[Catch: all -> 0x0079, TryCatch #1 {all -> 0x0079, blocks: (B:10:0x0019, B:12:0x0029, B:14:0x002f, B:17:0x003d, B:19:0x0056, B:20:0x0064, B:22:0x006f), top: B:34:0x0019 }] */
    /* JADX WARN: Code duplicated, block: B:22:0x006f A[Catch: all -> 0x0079, TRY_LEAVE, TryCatch #1 {all -> 0x0079, blocks: (B:10:0x0019, B:12:0x0029, B:14:0x002f, B:17:0x003d, B:19:0x0056, B:20:0x0064, B:22:0x006f), top: B:34:0x0019 }] */
    public final IdentifiersResult a() {
        String strA;
        IdentifiersResult identifiersResult = this.f;
        if (identifiersResult != null && identifiersResult.status == IdentifierStatus.OK) {
            Ho ho = this.e;
            String str = identifiersResult.id;
            ho.getClass();
            if (Ho.a(str)) {
                return identifiersResult;
            }
        }
        try {
            R9 r9 = this.c;
            r9.a.lock();
            r9.b.a();
            identifiersResult = this.f;
            if (identifiersResult == null || identifiersResult.status != IdentifierStatus.OK) {
                strA = AbstractC0332ib.a(FileUtils.getFileFromSdkStorage(this.d.a, "uuid.dat"));
                this.e.getClass();
                if (!Ho.a(strA)) {
                    strA = this.d.a(this.b.a(this.a));
                }
                this.e.getClass();
                if (Ho.a(strA)) {
                    IdentifiersResult identifiersResult2 = new IdentifiersResult(strA, IdentifierStatus.OK, null);
                    try {
                        this.f = identifiersResult2;
                    } catch (Throwable unused) {
                    }
                    identifiersResult = identifiersResult2;
                }
            } else {
                Ho ho2 = this.e;
                String str2 = identifiersResult.id;
                ho2.getClass();
                if (!Ho.a(str2)) {
                    strA = AbstractC0332ib.a(FileUtils.getFileFromSdkStorage(this.d.a, "uuid.dat"));
                    this.e.getClass();
                    if (!Ho.a(strA)) {
                        strA = this.d.a(this.b.a(this.a));
                    }
                    this.e.getClass();
                    if (Ho.a(strA)) {
                        IdentifiersResult identifiersResult3 = new IdentifiersResult(strA, IdentifierStatus.OK, null);
                        this.f = identifiersResult3;
                        identifiersResult = identifiersResult3;
                    }
                }
            }
        } catch (Throwable unused2) {
        }
        R9 r10 = this.c;
        r10.b.b();
        r10.a.unlock();
        return identifiersResult != null ? identifiersResult : new IdentifiersResult(null, IdentifierStatus.UNKNOWN, "Uuid must be obtained via async API AppMetrica#requestStartupParams(Context, StartupParamsCallback, List<String>)");
    }

    public Pd(Context context, InterfaceC0357jb interfaceC0357jb, R9 r9, Ve ve, Ho ho) {
        this.a = context;
        this.b = interfaceC0357jb;
        this.c = r9;
        this.d = ve;
        this.e = ho;
        try {
            r9.a();
            ve.a();
            r9.b();
        } catch (Throwable unused) {
            this.c.b();
        }
    }
}
