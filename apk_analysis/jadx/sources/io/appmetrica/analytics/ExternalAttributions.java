package io.appmetrica.analytics;

import io.appmetrica.analytics.impl.Ab;
import io.appmetrica.analytics.impl.Ae;
import io.appmetrica.analytics.impl.Ee;
import io.appmetrica.analytics.impl.EnumC0227ea;
import io.appmetrica.analytics.impl.Vc;
import java.util.Map;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class ExternalAttributions {
    public static ExternalAttribution adjust(Object obj) {
        return obj == null ? new Ae(EnumC0227ea.ADJUST) : new Ee(EnumC0227ea.ADJUST, obj);
    }

    public static ExternalAttribution airbridge(Map<String, String> map) {
        return map == null ? new Ae(EnumC0227ea.AIRBRIDGE) : new Vc(EnumC0227ea.AIRBRIDGE, map);
    }

    public static ExternalAttribution appsflyer(Map<String, Object> map) {
        return map == null ? new Ae(EnumC0227ea.APPSFLYER) : new Vc(EnumC0227ea.APPSFLYER, map);
    }

    public static ExternalAttribution kochava(JSONObject jSONObject) {
        return jSONObject == null ? new Ae(EnumC0227ea.KOCHAVA) : new Ab(EnumC0227ea.KOCHAVA, jSONObject);
    }

    public static ExternalAttribution singular(Map<String, Object> map) {
        return map == null ? new Ae(EnumC0227ea.SINGULAR) : new Vc(EnumC0227ea.SINGULAR, map);
    }

    public static ExternalAttribution tenjin(Map<String, String> map) {
        return map == null ? new Ae(EnumC0227ea.TENJIN) : new Vc(EnumC0227ea.TENJIN, map);
    }
}
