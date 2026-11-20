package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.IntIterator;
import com.scanflow.datacapture.barinternal.kotlin.ranges.IntRange;
import com.scanflow.datacapture.barinternal.kotlin.ranges.RangesKt;
import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Locale;
import java.util.concurrent.TimeUnit;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;
import org.json.JSONArray;
import org.json.JSONObject;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.yd, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0749yd implements InterfaceC0340ik {
    public final Ol a;
    public final String b;
    public final SystemTimeProvider c;
    public final List d;
    public final String e;
    public final long f;

    public C0749yd(Ol ol, String str, SystemTimeProvider systemTimeProvider, List<C0671vd> list) {
        this.a = ol;
        this.b = str;
        this.c = systemTimeProvider;
        this.d = list;
        this.e = str.toUpperCase(Locale.ROOT) + "_STATUS";
        this.f = TimeUnit.DAYS.toMillis(1L);
    }

    public final C0315hk a() {
        Nd nd;
        C0671vd c0671vd;
        if (this.d.isEmpty()) {
            return null;
        }
        List listSortedWith = CollectionsKt.sortedWith(this.d, new C0723xd());
        String strA = ((Sd) this.a).a(this.e, (String) null);
        if (strA != null) {
            try {
                JSONObject jSONObject = new JSONObject(strA);
                JSONArray jSONArray = jSONObject.getJSONArray("modulesStatus");
                IntRange intRangeUntil = RangesKt.until(0, jSONArray.length());
                ArrayList arrayList = new ArrayList(CollectionsKt.collectionSizeOrDefault(intRangeUntil, 10));
                Iterator it = intRangeUntil.iterator();
                while (it.hasNext()) {
                    JSONObject jSONObject2 = jSONArray.getJSONObject(((IntIterator) it).nextInt());
                    try {
                        c0671vd = new C0671vd(jSONObject2.getString("moduleName"), jSONObject2.getBoolean("loaded"));
                    } catch (Throwable unused) {
                        c0671vd = new C0671vd("", false);
                    }
                    arrayList.add(c0671vd);
                }
                nd = new Nd(arrayList, jSONObject.getLong("lastSendTime"));
            } catch (Throwable unused2) {
                nd = new Nd(CollectionsKt.emptyList(), 0L);
            }
        } else {
            nd = null;
        }
        long jCurrentTimeMillis = this.c.currentTimeMillis();
        if (nd != null && jCurrentTimeMillis - nd.b <= this.f && Intrinsics.areEqual(listSortedWith, nd.a)) {
            return null;
        }
        Nd nd2 = new Nd(listSortedWith, jCurrentTimeMillis);
        Ol ol = this.a;
        Sd sd = (Sd) ol;
        sd.d(sd.g(this.e), nd2.a());
        return new C0315hk(this.b + "_status", nd2.a());
    }

    public /* synthetic */ C0749yd(Ol ol, String str, SystemTimeProvider systemTimeProvider, List list, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this(ol, str, (i & 4) != 0 ? new SystemTimeProvider() : systemTimeProvider, list);
    }
}
