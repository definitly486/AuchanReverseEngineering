package io.appmetrica.analytics.impl;

import com.bumptech.glide.load.Key;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import java.io.UnsupportedEncodingException;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ln, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0421ln extends Z2 {
    public C0421ln(int i, String str) {
        this(i, str, PublicLogger.getAnonymousInstance());
    }

    public final int b() {
        return this.a;
    }

    public C0421ln(int i, String str, PublicLogger publicLogger) {
        super(i, str, publicLogger);
    }

    public final String a() {
        return this.b;
    }

    @Override // io.appmetrica.analytics.impl.Cdo
    public final String a(String str) {
        if (StringUtils.isNullOrEmpty(str)) {
            return str;
        }
        try {
            byte[] bytes = str.getBytes(Key.STRING_CHARSET_NAME);
            int length = bytes.length;
            int i = this.a;
            if (length <= i) {
                return str;
            }
            String str2 = new String(bytes, 0, i, Key.STRING_CHARSET_NAME);
            try {
                this.c.warning("\"%s\" %s exceeded limit of %d bytes", this.b, str, Integer.valueOf(this.a));
            } catch (UnsupportedEncodingException unused) {
            }
            return str2;
        } catch (UnsupportedEncodingException unused2) {
            return str;
        }
    }
}
