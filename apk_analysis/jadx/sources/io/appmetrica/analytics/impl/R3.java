package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class R3 extends AbstractC0354j8 {
    @Override // io.appmetrica.analytics.impl.AbstractC0354j8
    public final boolean a(I3 i3, I3 i4) {
        if (Do.a(i4.a)) {
            return true;
        }
        if (Do.a(i3.a)) {
            return false;
        }
        EnumC0406l8 enumC0406l8 = i3.b;
        if (enumC0406l8 == EnumC0406l8.d) {
            if (((Number) this.a.a(enumC0406l8)).intValue() >= ((Number) this.a.a(i4.b)).intValue()) {
                return true;
            }
        } else if (((Number) this.a.a(enumC0406l8)).intValue() > ((Number) this.a.a(i4.b)).intValue()) {
            return true;
        }
        return false;
    }
}
