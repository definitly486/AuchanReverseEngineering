package io.appmetrica.analytics.screenshot.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.IntIterator;
import com.scanflow.datacapture.barinternal.kotlin.ranges.IntRange;
import com.scanflow.datacapture.barinternal.kotlin.ranges.RangesKt;
import io.appmetrica.analytics.coreapi.internal.data.JsonParser;
import io.appmetrica.analytics.coreutils.internal.parsing.JsonUtils;
import io.appmetrica.analytics.coreutils.internal.parsing.RemoteConfigJsonUtils;
import io.appmetrica.analytics.screenshot.internal.config.RemoteScreenshotConfig;
import java.util.ArrayList;
import java.util.Iterator;
import kotlin.jvm.internal.DefaultConstructorMarker;
import org.json.JSONArray;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class I implements JsonParser {
    public final V a;
    public final U b;

    /* JADX WARN: Multi-variable type inference failed */
    public I() {
        this(null, 0 == true ? 1 : 0, 3, 0 == true ? 1 : 0);
    }

    public final RemoteScreenshotConfig b(JSONObject jSONObject) {
        return (RemoteScreenshotConfig) JsonParser.DefaultImpls.parseOrNull(this, jSONObject);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Parser
    public final Object parseOrNull(JSONObject jSONObject) {
        return (RemoteScreenshotConfig) JsonParser.DefaultImpls.parseOrNull(this, jSONObject);
    }

    public I(V v, U u) {
        this.a = v;
        this.b = u;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Parser
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final RemoteScreenshotConfig parse(JSONObject jSONObject) {
        K k;
        M m;
        N n;
        boolean zExtractFeature = RemoteConfigJsonUtils.extractFeature(jSONObject, "screenshot", AbstractC0801o.a);
        V v = this.a;
        U u = this.b;
        u.getClass();
        JSONObject jSONObjectOptJSONObject = jSONObject.optJSONObject("screenshot");
        if (jSONObjectOptJSONObject == null) {
            n = new N();
            n.a = new K();
            n.b = new M();
            L l = new L();
            l.c = AbstractC0801o.b;
            n.c = l;
        } else {
            N n2 = new N();
            u.a.getClass();
            JSONObject jSONObjectOptJSONObject2 = jSONObjectOptJSONObject.optJSONObject("api_captor_config");
            L l2 = null;
            if (jSONObjectOptJSONObject2 == null) {
                k = null;
            } else {
                k = new K();
                Boolean boolOptBooleanOrNull = JsonUtils.optBooleanOrNull(jSONObjectOptJSONObject2, "enabled");
                if (boolOptBooleanOrNull != null) {
                    k.a = boolOptBooleanOrNull.booleanValue();
                }
            }
            if (k != null) {
                n2.a = k;
            }
            u.b.getClass();
            JSONObject jSONObjectOptJSONObject3 = jSONObjectOptJSONObject.optJSONObject("service_captor_config");
            if (jSONObjectOptJSONObject3 == null) {
                m = null;
            } else {
                m = new M();
                Boolean boolOptBooleanOrNull2 = JsonUtils.optBooleanOrNull(jSONObjectOptJSONObject3, "enabled");
                if (boolOptBooleanOrNull2 != null) {
                    m.a = boolOptBooleanOrNull2.booleanValue();
                }
                Long lOptLongOrNull = JsonUtils.optLongOrNull(jSONObjectOptJSONObject3, "delay_seconds");
                if (lOptLongOrNull != null) {
                    m.b = lOptLongOrNull.longValue();
                }
            }
            if (m != null) {
                n2.b = m;
            }
            u.c.getClass();
            JSONObject jSONObjectOptJSONObject4 = jSONObjectOptJSONObject.optJSONObject("content_observer_captor_config");
            if (jSONObjectOptJSONObject4 != null) {
                l2 = new L();
                Boolean boolOptBooleanOrNull3 = JsonUtils.optBooleanOrNull(jSONObjectOptJSONObject4, "enabled");
                if (boolOptBooleanOrNull3 != null) {
                    l2.a = boolOptBooleanOrNull3.booleanValue();
                }
                JSONArray jSONArrayOptJSONArray = jSONObjectOptJSONObject4.optJSONArray("media_store_column_names");
                if (jSONArrayOptJSONArray != null) {
                    IntRange intRangeUntil = RangesKt.until(0, jSONArrayOptJSONArray.length());
                    ArrayList arrayList = new ArrayList(CollectionsKt.collectionSizeOrDefault(intRangeUntil, 10));
                    Iterator it = intRangeUntil.iterator();
                    while (it.hasNext()) {
                        arrayList.add(jSONArrayOptJSONArray.getString(((IntIterator) it).nextInt()));
                    }
                    l2.c = (String[]) arrayList.toArray(new String[0]);
                }
                Long lOptLongOrNull2 = JsonUtils.optLongOrNull(jSONObjectOptJSONObject4, "detect_window_seconds");
                if (lOptLongOrNull2 != null) {
                    l2.b = lOptLongOrNull2.longValue();
                }
            }
            if (l2 != null) {
                n2.c = l2;
            }
            n = n2;
        }
        return new RemoteScreenshotConfig(zExtractFeature, v.toModel(n));
    }

    public /* synthetic */ I(V v, U u, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this((i & 1) != 0 ? new V(null, null, null, 7, null) : v, (i & 2) != 0 ? new U() : u);
    }
}
