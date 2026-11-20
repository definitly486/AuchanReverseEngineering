package io.appmetrica.analytics.remotepermissions.impl;

import android.text.TextUtils;
import io.appmetrica.analytics.coreapi.internal.data.JsonParser;
import io.appmetrica.analytics.remotepermissions.internal.config.FeatureConfig;
import java.util.HashSet;
import org.json.JSONArray;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class c implements JsonParser {
    public final String a = "permissions";
    public final String b = "name";
    public final String c = "list";
    public final String d = "enabled";

    @Override // io.appmetrica.analytics.coreapi.internal.data.Parser
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final FeatureConfig parse(JSONObject jSONObject) {
        JSONArray jSONArrayOptJSONArray;
        HashSet hashSet = new HashSet();
        JSONObject jSONObjectOptJSONObject = jSONObject.optJSONObject(this.a);
        if (jSONObjectOptJSONObject != null && (jSONArrayOptJSONArray = jSONObjectOptJSONObject.optJSONArray(this.c)) != null) {
            int length = jSONArrayOptJSONArray.length();
            for (int i = 0; i < length; i++) {
                JSONObject jSONObjectOptJSONObject2 = jSONArrayOptJSONArray.optJSONObject(i);
                if (jSONObjectOptJSONObject2 != null && jSONObjectOptJSONObject2.optBoolean(this.d)) {
                    String strOptString = jSONObjectOptJSONObject2.optString(this.b);
                    if (!TextUtils.isEmpty(strOptString)) {
                        hashSet.add(strOptString);
                    }
                }
            }
        }
        return new FeatureConfig(hashSet);
    }

    public final FeatureConfig b(JSONObject jSONObject) {
        return (FeatureConfig) JsonParser.DefaultImpls.parseOrNull(this, jSONObject);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Parser
    public final Object parseOrNull(JSONObject jSONObject) {
        return (FeatureConfig) JsonParser.DefaultImpls.parseOrNull(this, jSONObject);
    }
}
