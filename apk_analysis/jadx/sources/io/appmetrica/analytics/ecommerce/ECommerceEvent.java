package io.appmetrica.analytics.ecommerce;

import io.appmetrica.analytics.impl.C0679vl;
import io.appmetrica.analytics.impl.C0731xl;
import io.appmetrica.analytics.impl.C0739y3;
import io.appmetrica.analytics.impl.C0783zl;
import io.appmetrica.analytics.impl.Ie;
import io.appmetrica.analytics.impl.InterfaceC0259fg;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public abstract class ECommerceEvent implements InterfaceC0259fg {
    protected ECommerceEvent() {
    }

    public static ECommerceEvent addCartItemEvent(ECommerceCartItem eCommerceCartItem) {
        return new C0739y3(4, eCommerceCartItem);
    }

    public static ECommerceEvent beginCheckoutEvent(ECommerceOrder eCommerceOrder) {
        return new Ie(6, eCommerceOrder);
    }

    public static ECommerceEvent purchaseEvent(ECommerceOrder eCommerceOrder) {
        return new Ie(7, eCommerceOrder);
    }

    public static ECommerceEvent removeCartItemEvent(ECommerceCartItem eCommerceCartItem) {
        return new C0739y3(5, eCommerceCartItem);
    }

    public static ECommerceEvent showProductCardEvent(ECommerceProduct eCommerceProduct, ECommerceScreen eCommerceScreen) {
        return new C0679vl(eCommerceProduct, eCommerceScreen);
    }

    public static ECommerceEvent showProductDetailsEvent(ECommerceProduct eCommerceProduct, ECommerceReferrer eCommerceReferrer) {
        return new C0731xl(eCommerceProduct, eCommerceReferrer);
    }

    public static ECommerceEvent showScreenEvent(ECommerceScreen eCommerceScreen) {
        return new C0783zl(eCommerceScreen);
    }

    public String getPublicDescription() {
        return "E-commerce base event";
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0259fg
    public abstract /* synthetic */ List toProto();
}
