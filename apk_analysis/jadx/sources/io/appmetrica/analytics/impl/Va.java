package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.StringUtils;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;
import java.util.Set;

/* JADX INFO: loaded from: classes3.dex */
public final class Va extends P2 {
    public final Sa b;
    public final Sa c;
    public final Ua d;

    public Va(int i, int i2, int i3) {
        this(i, new Sa(i2), new Sa(i3));
    }

    public Va(int i, Sa sa, Sa sa2) {
        super(i);
        this.d = new Ua();
        this.b = sa;
        this.c = sa2;
    }

    @Override // io.appmetrica.analytics.impl.P2, io.appmetrica.analytics.impl.Ta
    public final C0241eo a(Map<String, String> map) {
        HashMap map2;
        int bytesTruncated;
        int i = 0;
        if (map != null) {
            map2 = new HashMap();
            Set<Map.Entry<String, String>> setEntrySet = map.entrySet();
            Map.Entry[] entryArr = (Map.Entry[]) setEntrySet.toArray(new Map.Entry[setEntrySet.size()]);
            Arrays.sort(entryArr, this.d);
            int length = entryArr.length;
            bytesTruncated = 0;
            int i2 = 0;
            boolean z = false;
            int i3 = 0;
            while (i < length) {
                Map.Entry entry = entryArr[i];
                C0241eo c0241eoA = this.b.a((String) entry.getKey());
                C0241eo c0241eoA2 = this.c.a((String) entry.getValue());
                int utf8BytesLength = StringUtils.getUtf8BytesLength((String) entry.getValue()) + StringUtils.getUtf8BytesLength((String) entry.getKey());
                int utf8BytesLength2 = StringUtils.getUtf8BytesLength((String) c0241eoA2.a) + StringUtils.getUtf8BytesLength((String) c0241eoA.a);
                if (z || utf8BytesLength2 + i3 > this.a) {
                    i2++;
                    bytesTruncated += utf8BytesLength;
                    z = true;
                } else {
                    bytesTruncated = c0241eoA2.b.getBytesTruncated() + c0241eoA.b.getBytesTruncated() + bytesTruncated;
                    int utf8BytesLength3 = StringUtils.getUtf8BytesLength((String) c0241eoA2.a) + StringUtils.getUtf8BytesLength((String) c0241eoA.a) + i3;
                    map2.put((String) c0241eoA.a, (String) c0241eoA2.a);
                    i3 = utf8BytesLength3;
                }
                i++;
            }
            i = i2;
        } else {
            map2 = null;
            bytesTruncated = 0;
        }
        return new C0241eo(map2, new E4(i, bytesTruncated));
    }
}
