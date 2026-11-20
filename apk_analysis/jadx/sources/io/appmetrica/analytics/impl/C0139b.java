package io.appmetrica.analytics.impl;

import android.text.TextUtils;
import android.util.Base64;
import com.bumptech.glide.load.Key;
import io.appmetrica.analytics.coreutils.internal.encryption.AESEncrypter;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.b, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0139b implements InterfaceC0123a9 {
    public final AESEncrypter a;

    public C0139b() {
        this(new C0113a(Ka.k().g()));
    }

    /* JADX WARN: Code duplicated, block: B:8:0x001e  */
    @Override // io.appmetrica.analytics.impl.InterfaceC0123a9
    public final S8 a(C0249f6 c0249f6) {
        String strEncodeToString;
        String value = c0249f6.getValue();
        if (TextUtils.isEmpty(value)) {
            strEncodeToString = null;
        } else {
            try {
                byte[] bArrEncrypt = this.a.encrypt(value.getBytes(Key.STRING_CHARSET_NAME));
                if (bArrEncrypt != null) {
                    strEncodeToString = Base64.encodeToString(bArrEncrypt, 0);
                } else {
                    strEncodeToString = null;
                }
            } catch (Throwable unused) {
            }
        }
        c0249f6.setValue(strEncodeToString);
        return new S8(c0249f6, EnumC0175c9.AES_VALUE_ENCRYPTION);
    }

    public C0139b(C0113a c0113a) {
        this(new AESEncrypter(AESEncrypter.DEFAULT_ALGORITHM, c0113a.b(), c0113a.a()));
    }

    public C0139b(AESEncrypter aESEncrypter) {
        this.a = aESEncrypter;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0123a9
    public final byte[] a(byte[] bArr) {
        byte[] bArr2 = new byte[0];
        if (bArr != null && bArr.length > 0) {
            try {
                return this.a.decrypt(Base64.decode(bArr, 0));
            } catch (Throwable unused) {
            }
        }
        return bArr2;
    }

    public final EnumC0175c9 a() {
        return EnumC0175c9.AES_VALUE_ENCRYPTION;
    }
}
