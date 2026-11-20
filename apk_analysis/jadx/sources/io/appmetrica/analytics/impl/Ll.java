package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;

/* JADX INFO: loaded from: classes3.dex */
public final class Ll {
    public final Xc a;
    public final Wc b;

    public Ll(PublicLogger publicLogger, String str) {
        this(new Xc(str, publicLogger), new Wc(str, publicLogger));
    }

    /* JADX WARN: Multi-variable type inference failed */
    public final synchronized boolean a(C0127ad c0127ad, String str, String str2) {
        try {
            int size = c0127ad.size();
            int i = this.a.c.a;
            if (size < i || (i == c0127ad.size() && c0127ad.containsKey(str))) {
                this.b.getClass();
                int length = c0127ad.a;
                if (str2 != null) {
                    length += str2.length();
                }
                if (c0127ad.containsKey(str)) {
                    String str3 = (String) c0127ad.get(str);
                    if (str3 != null) {
                        length -= str3.length();
                    }
                } else {
                    length += str.length();
                }
                if (length <= 4500) {
                    c0127ad.put(str, str2);
                    return true;
                }
                Wc wc = this.b;
                wc.b.warning("The %s has reached the total size limit that equals %d symbols. Item with key %s will be ignored", wc.a, 4500, str);
            } else {
                Xc xc = this.a;
                xc.d.warning("The %s has reached the limit of %d items. Item with key %s will be ignored", xc.e, Integer.valueOf(xc.c.a), str);
            }
            return false;
        } catch (Throwable th) {
            throw th;
        }
    }

    public final boolean b(C0127ad c0127ad, String str, String str2) {
        if (c0127ad == null) {
            return false;
        }
        String strA = this.a.a.a(str);
        String strA2 = this.a.b.a(str2);
        if (!c0127ad.containsKey(strA)) {
            if (strA2 != null) {
                return a(c0127ad, strA, strA2);
            }
            return false;
        }
        String str3 = (String) c0127ad.get(strA);
        if (strA2 == null || !strA2.equals(str3)) {
            return a(c0127ad, strA, strA2);
        }
        return false;
    }

    public Ll(Xc xc, Wc wc) {
        this.a = xc;
        this.b = wc;
    }
}
