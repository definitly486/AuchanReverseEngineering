package io.appmetrica.analytics.impl;

import android.content.Context;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;
import io.appmetrica.analytics.coreutils.internal.io.BufferedFileWriter;
import io.appmetrica.analytics.coreutils.internal.io.FileUtils;
import java.io.File;
import kotlin.jvm.internal.DefaultConstructorMarker;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ya, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0746ya implements To {
    public static final C0720xa h = new C0720xa();
    public final Context a;
    public final String b;
    public final IHandlerExecutor c;
    public final long d;
    public final Object e;
    public volatile BufferedFileWriter f;
    public volatile boolean g;

    public C0746ya(Context context, String str, IHandlerExecutor iHandlerExecutor, long j) {
        this.a = context;
        this.b = str;
        this.c = iHandlerExecutor;
        this.d = j;
        this.e = new Object();
    }

    @Override // io.appmetrica.analytics.impl.To
    public final void a(String str) {
        try {
            BufferedFileWriter bufferedFileWriterC = c();
            if (bufferedFileWriterC != null) {
                bufferedFileWriterC.writeString(str);
            }
        } catch (Throwable unused) {
        }
    }

    @Override // io.appmetrica.analytics.impl.To
    public final String b() {
        try {
            BufferedFileWriter bufferedFileWriterC = c();
            if (bufferedFileWriterC == null) {
                return null;
            }
            d();
            return bufferedFileWriterC.readString();
        } catch (Throwable unused) {
            return null;
        }
    }

    public final BufferedFileWriter c() {
        BufferedFileWriter bufferedFileWriter = this.f;
        if (bufferedFileWriter != null) {
            return bufferedFileWriter;
        }
        synchronized (this.e) {
            BufferedFileWriter bufferedFileWriter2 = this.f;
            if (bufferedFileWriter2 != null) {
                return bufferedFileWriter2;
            }
            File fileFromSdkStorage = FileUtils.getFileFromSdkStorage(this.a, this.b);
            if (fileFromSdkStorage == null) {
                return null;
            }
            BufferedFileWriter bufferedFileWriter3 = new BufferedFileWriter(this.c, this.d, fileFromSdkStorage);
            this.f = bufferedFileWriter3;
            return bufferedFileWriter3;
        }
    }

    public final void d() {
        File fileFromAppStorage;
        if (this.g) {
            return;
        }
        synchronized (this.e) {
            if (this.g) {
                return;
            }
            try {
                File fileFromSdkStorage = FileUtils.getFileFromSdkStorage(this.a, this.b);
                if (fileFromSdkStorage != null && !fileFromSdkStorage.exists() && (fileFromAppStorage = FileUtils.getFileFromAppStorage(this.a, this.b)) != null) {
                    FileUtils.copyToNullable(fileFromAppStorage, fileFromSdkStorage);
                }
            } catch (Throwable unused) {
            }
            this.g = true;
            Unit unit = Unit.INSTANCE;
        }
    }

    @Override // io.appmetrica.analytics.impl.To
    public final void flushAsync() {
        try {
            BufferedFileWriter bufferedFileWriterC = c();
            if (bufferedFileWriterC != null) {
                bufferedFileWriterC.flushAsync();
            }
        } catch (Throwable unused) {
        }
    }

    @Override // io.appmetrica.analytics.impl.To
    public final void a() {
        try {
            BufferedFileWriter bufferedFileWriterC = c();
            if (bufferedFileWriterC != null) {
                bufferedFileWriterC.flush();
            }
        } catch (Throwable unused) {
        }
    }

    public /* synthetic */ C0746ya(Context context, String str, IHandlerExecutor iHandlerExecutor, long j, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this(context, str, iHandlerExecutor, (i & 8) != 0 ? 1000L : j);
    }
}
