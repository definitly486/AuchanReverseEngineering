package io.appmetrica.analytics.impl;

import java.util.List;
import java.util.Set;
import org.json.JSONArray;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.rf, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0569rf implements Ol {
    public static final String c = "rf";
    public final InterfaceC0280gb a;
    public final String b;

    public AbstractC0569rf(InterfaceC0280gb interfaceC0280gb) {
        this(interfaceC0280gb, null);
    }

    public abstract /* synthetic */ int a(String str, int i);

    public abstract /* synthetic */ long a(String str, long j);

    /* JADX WARN: Multi-variable type inference failed */
    public final <T extends AbstractC0569rf> T a(String str, float f) {
        synchronized (this) {
            this.a.a(str, f);
        }
        return this;
    }

    public abstract /* synthetic */ String a(String str, String str2);

    public abstract /* synthetic */ boolean a(String str, boolean z);

    public abstract /* synthetic */ Ol b(String str, int i);

    public abstract /* synthetic */ Ol b(String str, long j);

    public abstract /* synthetic */ Ol b(String str, String str2);

    public abstract /* synthetic */ Ol b(String str, boolean z);

    public abstract /* synthetic */ boolean b(String str);

    public final long c(String str, long j) {
        return this.a.getLong(str, j);
    }

    public final C0595sf d(String str) {
        return new C0595sf(str, this.b);
    }

    public abstract /* synthetic */ Ol e(String str);

    /* JADX WARN: Multi-variable type inference failed */
    public final <T extends AbstractC0569rf> T f(String str) {
        synchronized (this) {
            this.a.remove(str);
        }
        return this;
    }

    @Override // io.appmetrica.analytics.impl.Ol, io.appmetrica.analytics.impl.To
    public void flushAsync() {
        this.a.flushAsync();
    }

    public AbstractC0569rf(InterfaceC0280gb interfaceC0280gb, String str) {
        this.a = interfaceC0280gb;
        this.b = str;
    }

    public final int c(String str, int i) {
        return this.a.getInt(str, i);
    }

    public final String c(String str, String str2) {
        return this.a.getString(str, str2);
    }

    public final boolean c(String str, boolean z) {
        return this.a.getBoolean(str, z);
    }

    /* JADX WARN: Multi-variable type inference failed */
    public final <T extends AbstractC0569rf> T d(String str, String str2) {
        synchronized (this) {
            this.a.a(str, str2);
        }
        return this;
    }

    /* JADX WARN: Multi-variable type inference failed */
    public final <T extends AbstractC0569rf> T a(String str, String[] strArr) {
        String string;
        try {
            JSONArray jSONArray = new JSONArray();
            for (String str2 : strArr) {
                jSONArray.put(str2);
            }
            string = jSONArray.toString();
        } catch (Throwable unused) {
            string = null;
        }
        this.a.a(str, string);
        return this;
    }

    public final boolean c(String str) {
        return this.a.a(str);
    }

    public Set<String> c() {
        return this.a.b();
    }

    /* JADX WARN: Multi-variable type inference failed */
    public final <T extends AbstractC0569rf> T d(String str, long j) {
        synchronized (this) {
            this.a.a(str, j);
        }
        return this;
    }

    /* JADX WARN: Multi-variable type inference failed */
    public final <T extends AbstractC0569rf> T d(String str, int i) {
        synchronized (this) {
            this.a.a(str, i);
        }
        return this;
    }

    public final <T extends AbstractC0569rf> T a(String str, List<String> list) {
        return (T) a(str, (String[]) list.toArray(new String[list.size()]));
    }

    public void a() {
        synchronized (this) {
            this.a.a();
        }
    }

    /* JADX WARN: Multi-variable type inference failed */
    public final <T extends AbstractC0569rf> T d(String str, boolean z) {
        synchronized (this) {
            this.a.a(str, z);
        }
        return this;
    }
}
