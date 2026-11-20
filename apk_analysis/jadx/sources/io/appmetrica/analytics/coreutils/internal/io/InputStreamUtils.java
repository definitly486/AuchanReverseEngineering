package io.appmetrica.analytics.coreutils.internal.io;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.io.CloseableKt;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import kotlin.jvm.functions.Function0;

/* JADX INFO: loaded from: classes3.dex */
public final class InputStreamUtils {
    public static final InputStreamUtils INSTANCE = new InputStreamUtils();

    private InputStreamUtils() {
    }

    public final byte[] readSafelyApprox(int i, Function0<? extends InputStream> function0) {
        try {
            InputStream inputStreamInvoke = function0.invoke();
            if (inputStreamInvoke != null) {
                try {
                    ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
                    try {
                        try {
                            byte[] bArr = new byte[8192];
                            int i2 = 0;
                            while (true) {
                                int i3 = inputStreamInvoke.read(bArr);
                                if (-1 == i3 || i2 > i) {
                                    break;
                                    break;
                                }
                                if (i3 > 0) {
                                    byteArrayOutputStream.write(bArr, 0, i3);
                                    i2 += i3;
                                }
                            }
                            byte[] byteArray = byteArrayOutputStream.toByteArray();
                            CloseableKt.closeFinally(byteArrayOutputStream, null);
                            CloseableKt.closeFinally(inputStreamInvoke, null);
                            return byteArray;
                        } catch (Throwable unused) {
                            Unit unit = Unit.INSTANCE;
                            CloseableKt.closeFinally(byteArrayOutputStream, null);
                            CloseableKt.closeFinally(inputStreamInvoke, null);
                            return new byte[0];
                        }
                    } catch (Throwable th) {
                        try {
                            throw th;
                        } catch (Throwable th2) {
                            CloseableKt.closeFinally(byteArrayOutputStream, th);
                            throw th2;
                        }
                    }
                } catch (Throwable th3) {
                    try {
                        throw th3;
                    } catch (Throwable th4) {
                        CloseableKt.closeFinally(inputStreamInvoke, th3);
                        throw th4;
                    }
                }
            }
        } catch (Throwable unused2) {
        }
        return new byte[0];
    }
}
