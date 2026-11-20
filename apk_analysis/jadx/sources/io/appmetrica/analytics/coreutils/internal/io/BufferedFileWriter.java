package io.appmetrica.analytics.coreutils.internal.io;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.io.FilesKt;
import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;
import io.appmetrica.analytics.coreutils.internal.buffering.BatchProcessor;
import io.appmetrica.analytics.coreutils.internal.buffering.DeferredBatchExecutor;
import io.appmetrica.analytics.coreutils.internal.buffering.LastValueTaskBuffer;
import io.appmetrica.analytics.coreutils.internal.io.BufferedFileWriter;
import java.io.File;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class BufferedFileWriter {
    private final File a;
    private final Object b;
    private String c;
    private final DeferredBatchExecutor d;

    public BufferedFileWriter(IHandlerExecutor iHandlerExecutor, long j, File file) {
        this.a = file;
        String str = "[BufferedFileWriter-" + file.getName() + ']';
        this.b = new Object();
        this.d = new DeferredBatchExecutor(iHandlerExecutor, new LastValueTaskBuffer(), new BatchProcessor() { // from class: com.scanflow.datacapture.barinternal.io.appmetrica.analytics.coreutils.internal.io.BufferedFileWriter$$ExternalSyntheticLambda0
            @Override // io.appmetrica.analytics.coreutils.internal.buffering.BatchProcessor
            public final void processBatch(List list) {
                BufferedFileWriter.a(this.f$0, list);
            }
        }, j, str);
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final void a(BufferedFileWriter bufferedFileWriter, List list) {
        String str = (String) CollectionsKt.first(list);
        try {
            File parentFile = bufferedFileWriter.a.getParentFile();
            if (parentFile != null) {
                if (parentFile.exists()) {
                    parentFile = null;
                }
                if (parentFile != null) {
                    parentFile.mkdirs();
                }
            }
            FilesKt.writeText$default(bufferedFileWriter.a, str, null, 2, null);
            synchronized (bufferedFileWriter.b) {
                bufferedFileWriter.c = null;
                Unit unit = Unit.INSTANCE;
            }
        } catch (Exception unused) {
        }
    }

    public final void flush() {
        this.d.flush();
    }

    public final void flushAsync() {
        this.d.flushAsync();
    }

    public final String readString() {
        String text$default;
        synchronized (this.b) {
            text$default = this.c;
            if (text$default == null) {
                text$default = null;
                try {
                    if (this.a.exists()) {
                        text$default = FilesKt.readText$default(this.a, null, 1, null);
                    }
                } catch (Exception unused) {
                }
                if (text$default != null) {
                    this.c = text$default;
                }
            }
        }
        return text$default;
    }

    public final void writeString(String str) {
        synchronized (this.b) {
            this.c = str;
            Unit unit = Unit.INSTANCE;
        }
        DeferredBatchExecutor.submit$default(this.d, str, false, 2, null);
    }
}
