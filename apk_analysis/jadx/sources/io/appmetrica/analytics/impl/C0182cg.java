package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.collection.CollectionUtils;
import io.appmetrica.analytics.ecommerce.ECommerceProduct;
import java.util.List;
import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.cg, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0182cg {
    public final String a;
    public final String b;
    public final List c;
    public final Map d;
    public final Uf e;
    public final Uf f;
    public final List g;

    public C0182cg(ECommerceProduct eCommerceProduct) {
        this(eCommerceProduct.getSku(), eCommerceProduct.getName(), CollectionUtils.arrayListCopyOfNullableCollection(eCommerceProduct.getCategoriesPath()), CollectionUtils.mapCopyOfNullableMap(eCommerceProduct.getPayload()), eCommerceProduct.getActualPrice() == null ? null : new Uf(eCommerceProduct.getActualPrice()), eCommerceProduct.getOriginalPrice() != null ? new Uf(eCommerceProduct.getOriginalPrice()) : null, CollectionUtils.arrayListCopyOfNullableCollection(eCommerceProduct.getPromocodes()));
    }

    public final String toString() {
        return "ProductWrapper{sku='" + this.a + "', name='" + this.b + "', categoriesPath=" + this.c + ", payload=" + this.d + ", actualPrice=" + this.e + ", originalPrice=" + this.f + ", promocodes=" + this.g + '}';
    }

    public C0182cg(String str, String str2, List list, Map map, Uf uf, Uf uf2, List list2) {
        this.a = str;
        this.b = str2;
        this.c = list;
        this.d = map;
        this.e = uf;
        this.f = uf2;
        this.g = list2;
    }
}
