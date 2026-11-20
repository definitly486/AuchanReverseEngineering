package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.StringUtils;
import io.appmetrica.analytics.protobuf.nano.CodedOutputByteBufferNano;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class Je implements InterfaceC0640u8 {
    public final Ne a;
    public final A3 b;
    public final Sa c;
    public final C0233eg d;

    public Je() {
        this(new Ne(), new A3(), new Sa(100), new C0233eg());
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final List<Qi> fromModel(Ie ie) {
        Qi qiFromModel;
        N8 n8 = new N8();
        n8.a = ie.a;
        n8.f = new C8();
        Ke ke = ie.b;
        A8 a8 = new A8();
        a8.a = StringUtils.getUTF8Bytes(ke.a);
        C0241eo c0241eoA = this.c.a(ke.b);
        a8.b = StringUtils.getUTF8Bytes((String) c0241eoA.a);
        a8.e = ke.c.size();
        Map<String, String> map = ke.d;
        if (map != null) {
            qiFromModel = this.a.fromModel(map);
            a8.c = (E8) qiFromModel.a;
        } else {
            qiFromModel = null;
        }
        n8.f.a = a8;
        int i = 0;
        char c = 1;
        C0532q3 c0532q3 = new C0532q3(C0532q3.b(c0241eoA, qiFromModel));
        List list = ke.c;
        ArrayList arrayList = new ArrayList();
        this.d.getClass();
        int iComputeInt32Size = n8.a != new N8().a ? CodedOutputByteBufferNano.computeInt32Size(1, n8.a) : 0;
        M8 m8 = n8.b;
        if (m8 != null) {
            iComputeInt32Size += CodedOutputByteBufferNano.computeMessageSize(2, m8);
        }
        K8 k8 = n8.c;
        if (k8 != null) {
            iComputeInt32Size += CodedOutputByteBufferNano.computeMessageSize(3, k8);
        }
        L8 l8 = n8.d;
        int i2 = 4;
        if (l8 != null) {
            iComputeInt32Size += CodedOutputByteBufferNano.computeMessageSize(4, l8);
        }
        C0692w8 c0692w8 = n8.e;
        if (c0692w8 != null) {
            iComputeInt32Size += CodedOutputByteBufferNano.computeMessageSize(5, c0692w8);
        }
        C8 c8 = n8.f;
        if (c8 != null) {
            iComputeInt32Size += CodedOutputByteBufferNano.computeMessageSize(6, c8);
        }
        ArrayList arrayList2 = new ArrayList();
        N8 n9 = new N8();
        n9.a = n8.a;
        C8 c9 = new C8();
        n9.f = c9;
        c9.a = new A8();
        A8 a9 = n9.f.a;
        A8 a10 = n8.f.a;
        a9.b = a10.b;
        a9.a = a10.a;
        a9.e = a10.e;
        a9.c = a10.c;
        C0532q3 c0532q4 = c0532q3;
        int i3 = 0;
        int i4 = iComputeInt32Size;
        while (i3 < list.size()) {
            B3 b3 = (B3) list.get(i3);
            char c2 = c;
            B8 b8 = new B8();
            b8.a = i3;
            int i5 = i;
            Qi qiFromModel2 = this.b.fromModel(b3);
            b8.b = (C0718x8) qiFromModel2.a;
            qiFromModel2.b.getBytesTruncated();
            Qi qi = new Qi(b8, qiFromModel2);
            C0233eg c0233eg = this.d;
            B8 b9 = (B8) qi.a;
            c0233eg.getClass();
            int iComputeTagSize = CodedOutputByteBufferNano.computeTagSize(i2);
            int iComputeMessageSizeNoTag = CodedOutputByteBufferNano.computeMessageSizeNoTag(b9);
            int iComputeRawVarint32Size = iComputeTagSize + iComputeMessageSizeNoTag + ((iComputeMessageSizeNoTag & (-128)) == 0 ? i5 : CodedOutputByteBufferNano.computeRawVarint32Size(iComputeMessageSizeNoTag));
            if (arrayList2.size() != 0 && i4 + iComputeRawVarint32Size > 204800) {
                n9.f.a.d = (B8[]) arrayList2.toArray(new B8[arrayList2.size()]);
                ArrayList arrayList3 = new ArrayList();
                arrayList.add(new Qi(n9, c0532q4));
                N8 n10 = new N8();
                n10.a = n8.a;
                C8 c10 = new C8();
                n10.f = c10;
                c10.a = new A8();
                A8 a11 = n10.f.a;
                A8 a12 = n8.f.a;
                a11.b = a12.b;
                a11.a = a12.a;
                a11.e = a12.e;
                a11.c = a12.c;
                c0532q4 = c0532q3;
                i4 = iComputeInt32Size;
                n9 = n10;
                arrayList2 = arrayList3;
            }
            arrayList2.add((B8) qi.a);
            InterfaceC0557r3 interfaceC0557r3 = qi.b;
            InterfaceC0557r3[] interfaceC0557r3Arr = new InterfaceC0557r3[2];
            interfaceC0557r3Arr[i5] = c0532q4;
            interfaceC0557r3Arr[c2] = interfaceC0557r3;
            c0532q4 = new C0532q3(C0532q3.b(interfaceC0557r3Arr));
            i4 += iComputeRawVarint32Size;
            i3++;
            c = c2;
            i = i5;
            i2 = 4;
        }
        n9.f.a.d = (B8[]) arrayList2.toArray(new B8[arrayList2.size()]);
        arrayList.add(new Qi(n9, c0532q4));
        return arrayList;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public Je(Ne ne, A3 a3, Sa sa, C0233eg c0233eg) {
        this.a = ne;
        this.b = a3;
        this.c = sa;
        this.d = c0233eg;
    }

    public final Ie a(List<Qi> list) {
        throw new UnsupportedOperationException();
    }
}
