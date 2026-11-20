package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class Sa extends P2 {
    public Sa(int i) {
        super(i);
    }

    @Override // io.appmetrica.analytics.impl.P2, io.appmetrica.analytics.impl.Ta
    public final C0241eo a(String str) {
        int length = 0;
        if (str != null) {
            int length2 = str.length();
            int i = this.a;
            if (length2 > i) {
                String strSubstring = str.substring(0, i);
                length = str.getBytes().length - strSubstring.getBytes().length;
                str = strSubstring;
            }
        }
        return new C0241eo(str, new C0532q3(length));
    }
}
