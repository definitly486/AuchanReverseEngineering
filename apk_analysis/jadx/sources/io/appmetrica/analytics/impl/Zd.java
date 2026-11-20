package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.io.ByteStreamsKt;
import io.appmetrica.analytics.coreapi.internal.backport.Function;
import io.appmetrica.analytics.coreutils.internal.io.Base64Utils;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import java.io.Closeable;
import java.io.File;
import java.io.FileInputStream;

/* JADX INFO: loaded from: classes3.dex */
public final class Zd implements Function {
    public final C0154be a;
    public final Yd b;

    public Zd(C0154be c0154be, Yd yd) {
        this.a = c0154be;
        this.b = yd;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.backport.Function
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final String apply(File file) {
        byte[] bytes;
        FileInputStream fileInputStream;
        try {
            String absolutePath = file.getAbsolutePath();
            if (absolutePath != null) {
                try {
                    fileInputStream = new FileInputStream(new File(absolutePath));
                    try {
                        bytes = ByteStreamsKt.readBytes(fileInputStream);
                        Do.a((Closeable) fileInputStream);
                    } catch (Throwable unused) {
                        Do.a((Closeable) fileInputStream);
                        bytes = null;
                    }
                } catch (Throwable unused2) {
                    fileInputStream = null;
                }
            } else {
                bytes = null;
            }
            if (bytes == null) {
                return null;
            }
            if (bytes.length == 0) {
                bytes = null;
            }
            if (bytes != null) {
                return Base64Utils.compressBase64(MessageNano.toByteArray(this.b.fromModel(new C0231ee(bytes, this.a))));
            }
            return null;
        } catch (Throwable unused3) {
            return null;
        }
    }
}
