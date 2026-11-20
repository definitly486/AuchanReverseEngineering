package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;
import io.appmetrica.analytics.coreapi.internal.permission.PermissionState;
import java.util.ArrayList;
import java.util.Iterator;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.h2, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0297h2 implements ProtobufConverter {
    public final I2 a;

    public C0297h2() {
        this(new I2());
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0374k2 fromModel(C0271g2 c0271g2) {
        C0374k2 c0374k2 = new C0374k2();
        c0374k2.a = new C0348j2[c0271g2.a.size()];
        int i = 0;
        int i2 = 0;
        for (PermissionState permissionState : c0271g2.a) {
            C0348j2[] c0348j2Arr = c0374k2.a;
            C0348j2 c0348j2 = new C0348j2();
            c0348j2.a = permissionState.name;
            c0348j2.b = permissionState.granted;
            c0348j2Arr[i2] = c0348j2;
            i2++;
        }
        K2 k2 = c0271g2.b;
        if (k2 != null) {
            c0374k2.b = this.a.fromModel(k2);
        }
        c0374k2.c = new String[c0271g2.c.size()];
        Iterator it = c0271g2.c.iterator();
        while (it.hasNext()) {
            c0374k2.c[i] = (String) it.next();
            i++;
        }
        return c0374k2;
    }

    public C0297h2(I2 i2) {
        this.a = i2;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0271g2 toModel(C0374k2 c0374k2) {
        ArrayList arrayList = new ArrayList();
        int i = 0;
        int i2 = 0;
        while (true) {
            C0348j2[] c0348j2Arr = c0374k2.a;
            if (i2 >= c0348j2Arr.length) {
                break;
            }
            C0348j2 c0348j2 = c0348j2Arr[i2];
            arrayList.add(new PermissionState(c0348j2.a, c0348j2.b));
            i2++;
        }
        C0323i2 c0323i2 = c0374k2.b;
        K2 model = c0323i2 != null ? this.a.toModel(c0323i2) : null;
        ArrayList arrayList2 = new ArrayList();
        while (true) {
            String[] strArr = c0374k2.c;
            if (i < strArr.length) {
                arrayList2.add(strArr[i]);
                i++;
            } else {
                return new C0271g2(arrayList, model, arrayList2);
            }
        }
    }
}
