package com.google.crypto.tink.internal;

import com.google.crypto.tink.Parameters;
import java.security.GeneralSecurityException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/* JADX INFO: loaded from: classes2.dex */
public final class MutableParametersRegistry {
    private static final MutableParametersRegistry globalInstance = new MutableParametersRegistry();
    private final Map<String, Parameters> parametersMap = new HashMap();

    MutableParametersRegistry() {
    }

    public static MutableParametersRegistry globalInstance() {
        return globalInstance;
    }

    public synchronized void put(String str, Parameters parameters) {
        try {
            if (this.parametersMap.containsKey(str)) {
                if (this.parametersMap.get(str).equals(parameters)) {
                    return;
                }
                throw new GeneralSecurityException("Parameters object with name " + str + " already exists (" + this.parametersMap.get(str) + "), cannot insert " + parameters);
            }
            this.parametersMap.put(str, parameters);
        } catch (Throwable th) {
            throw th;
        }
    }

    public synchronized Parameters get(String str) {
        if (this.parametersMap.containsKey(str)) {
        } else {
            throw new GeneralSecurityException("Name " + str + " does not exist");
        }
        return this.parametersMap.get(str);
    }

    public synchronized void putAll(Map<String, Parameters> map) {
        for (Map.Entry<String, Parameters> entry : map.entrySet()) {
            put(entry.getKey(), entry.getValue());
        }
    }

    public synchronized List<String> getNames() {
        ArrayList arrayList;
        arrayList = new ArrayList();
        arrayList.addAll(this.parametersMap.keySet());
        return Collections.unmodifiableList(arrayList);
    }
}
