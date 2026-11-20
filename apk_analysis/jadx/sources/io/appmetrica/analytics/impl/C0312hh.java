package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.IBinaryDataHelper;
import io.appmetrica.analytics.coreutils.internal.StringUtils;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.hh, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0312hh extends AbstractC0131ah {
    public final C0278g9 b;

    public C0312hh(C0455n5 c0455n5) {
        this(c0455n5, c0455n5.j());
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0131ah
    public final boolean a(C0249f6 c0249f6) {
        Aa aa;
        if (!StringUtils.isNullOrEmpty(c0249f6.getName())) {
            C0278g9 c0278g9 = this.b;
            String name = c0249f6.getName();
            if (c0278g9.c == null) {
                c0278g9.a();
            }
            int iHashCode = name.hashCode();
            if (c0278g9.c.b.contains(Integer.valueOf(iHashCode))) {
                aa = Aa.NON_FIRST_OCCURENCE;
            } else {
                C0330i9 c0330i9 = c0278g9.c;
                Aa aa2 = c0330i9.a ? Aa.FIRST_OCCURRENCE : Aa.UNKNOWN;
                if (c0330i9.d < 1000) {
                    c0330i9.b.add(Integer.valueOf(iHashCode));
                    c0330i9.d++;
                } else {
                    c0330i9.a = false;
                }
                C0407l9 c0407l9 = c0278g9.b;
                C0330i9 c0330i10 = c0278g9.c;
                IBinaryDataHelper iBinaryDataHelper = c0407l9.c;
                C0381k9 c0381k9 = c0407l9.b;
                c0407l9.a.getClass();
                iBinaryDataHelper.insert("event_hashes", c0381k9.toByteArray(C0355j9.a(c0330i10)));
                aa = aa2;
            }
            c0249f6.k = aa;
        }
        return false;
    }

    public C0312hh(C0455n5 c0455n5, C0278g9 c0278g9) {
        super(c0455n5);
        this.b = c0278g9;
    }
}
