package io.appmetrica.analytics.impl;

import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class Bb extends JSONObject {
    public Bb() {
    }

    public final Boolean a(String str) {
        try {
            return Boolean.valueOf(getBoolean(str));
        } catch (Throwable unused) {
            return null;
        }
    }

    public final Long b(String str) {
        try {
            return Long.valueOf(getLong(str));
        } catch (Throwable unused) {
            return null;
        }
    }

    public Bb(String str) {
        super(str);
    }

    public final String c(String str) {
        if (!has(str)) {
            return "";
        }
        try {
            return getString(str);
        } catch (Throwable unused) {
            return "";
        }
    }
}
