package io.appmetrica.analytics.impl;

import android.content.Context;
import android.content.Intent;
import android.content.res.Configuration;
import android.net.Uri;
import android.os.Bundle;
import android.text.TextUtils;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import io.appmetrica.analytics.AppMetrica;
import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;
import io.appmetrica.analytics.coreutils.internal.executors.BlockingExecutor;
import io.appmetrica.analytics.coreutils.internal.io.FileUtils;
import io.appmetrica.analytics.internal.CounterConfiguration;
import io.appmetrica.analytics.ndkcrashesapi.internal.NativeCrash;
import io.appmetrica.analytics.ndkcrashesapi.internal.NativeCrashServiceConfig;
import io.appmetrica.analytics.networktasks.internal.NetworkServiceLocator;
import java.io.File;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Objects;

/* JADX INFO: loaded from: classes3.dex */
public final class O1 implements C1, InterfaceC0632u0 {
    public boolean a;
    public final Context b;
    public final B1 c;
    public final C0558r4 d;
    public final W1 e;
    public C0157bh f;
    public final Ba g;
    public final C0608t2 h;
    public final P1 i;
    public final C0546qh j;

    public O1(Context context, B1 b1) {
        this(context, b1, new C0611t5(context));
    }

    public static void e(Intent intent) {
        Qo qo = Ka.I.D().c.a;
        Qo.a(qo.a);
        Qo.a(qo.b);
    }

    public final void a() {
        this.e.c(new V1() { // from class: io.appmetrica.analytics.impl.O1$$ExternalSyntheticLambda0
            @Override // io.appmetrica.analytics.impl.V1
            public final void a(Intent intent) {
                this.f$0.d(intent);
            }
        });
        this.e.a(new V1() { // from class: io.appmetrica.analytics.impl.O1$$ExternalSyntheticLambda1
            @Override // io.appmetrica.analytics.impl.V1
            public final void a(Intent intent) {
                O1.e(intent);
            }
        });
    }

    @Override // io.appmetrica.analytics.impl.C1
    public final void b(Intent intent) {
        this.e.d(intent);
        if (intent != null) {
            String action = intent.getAction();
            Uri data = intent.getData();
            String encodedAuthority = data == null ? null : data.getEncodedAuthority();
            if (!"io.appmetrica.analytics.IAppMetricaService".equals(action) || encodedAuthority == null || data == null || !Objects.equals(data.getPath(), "/client")) {
                return;
            }
            int i = Integer.parseInt(data.getQueryParameter("pid"));
            this.d.a(encodedAuthority, Integer.valueOf(i), data.getQueryParameter("psid"));
            this.h.a(i);
        }
    }

    @Override // io.appmetrica.analytics.impl.C1
    public final void c(Intent intent) {
        W1 w1 = this.e;
        if (intent == null) {
            w1.getClass();
            return;
        }
        w1.getClass();
        String action = intent.getAction();
        if (!TextUtils.isEmpty(action)) {
            w1.a.a(action, Integer.valueOf(W1.a(intent)));
        }
        for (Map.Entry entry : w1.b.entrySet()) {
            V1 v1 = (V1) entry.getKey();
            if (((U1) entry.getValue()).a(intent)) {
                v1.a(intent);
            }
        }
    }

    public final void d(Intent intent) {
        Ka.I.v().a(Cb.e(intent.getStringExtra("screen_size")));
    }

    @Override // io.appmetrica.analytics.impl.C1
    public final void onConfigurationChanged(Configuration configuration) {
        Ka.I.v().a(configuration);
    }

    @Override // io.appmetrica.analytics.impl.C1
    public final void onCreate() {
        if (this.a) {
            Ka.I.v().a(this.b.getResources().getConfiguration());
        } else {
            this.g.b(this.b);
            Ka ka = Ka.I;
            synchronized (ka) {
                ka.B.initAsync();
                ka.u.a(ka.a);
                ka.u.a(new Bo(ka.B));
                NetworkServiceLocator.init(ka.a, new C0663v5(new Ci(ka.h()), new F5(ka.a)));
                ka.l().a(ka.q);
                ka.E();
            }
            AbstractC0470nk.a.e();
            C0758ym c0758ym = Ka.I.u;
            c0758ym.a();
            C0706wm c0706wmA = c0758ym.a();
            Ok okP = Ka.I.p();
            okP.a(new C0626tk(new C0645ud(this.e)), c0706wmA);
            c0758ym.a(okP);
            ((Rl) Ka.I.z()).getClass();
            a();
            Ka.I.m().init();
            Ka.I.c().init();
            P1 p1 = this.i;
            Context context = this.b;
            C0558r4 c0558r4 = this.d;
            p1.getClass();
            this.f = new C0157bh(context, c0558r4);
            Context context2 = this.b;
            AbstractC0685w1.a.c(context2);
            AppMetrica.getReporter(context2, "20799a27-fa80-4b36-b2db-0f8141f24180");
            Context context3 = this.b;
            C0157bh c0157bh = this.f;
            C0335ie c0335ieR = Ka.k().r();
            IHandlerExecutor iHandlerExecutorF = Ka.k().w().f();
            C0690w6 c0690w6 = new C0690w6(context3, c0157bh, EnumC0721xb.EVENT_TYPE_PREV_SESSION_EXCEPTION_UNHANDLED_FROM_FILE, new Z(), new BlockingExecutor(), "previous", new C0616ta());
            C0690w6 c0690w7 = new C0690w6(context3, c0157bh, EnumC0721xb.EVENT_TYPE_EXCEPTION_UNHANDLED_FROM_FILE, new Ib(), iHandlerExecutorF, "actual", new C0616ta());
            File crashesDirectory = FileUtils.getCrashesDirectory(context3);
            if (crashesDirectory != null) {
                FileObserverC0638u6 fileObserverC0638u6 = new FileObserverC0638u6(crashesDirectory, c0690w7, new C0694wa());
                iHandlerExecutorF.execute(new RunnableC0518pg(crashesDirectory, c0690w6));
                if (!crashesDirectory.exists()) {
                    crashesDirectory.mkdir();
                } else if (!crashesDirectory.isDirectory() && crashesDirectory.delete()) {
                    crashesDirectory.mkdir();
                }
                fileObserverC0638u6.startWatching();
                Ka.I.E.storeReference(fileObserverC0638u6);
            }
            c0335ieR.getClass();
            File nativeCrashDirectory = FileUtils.getNativeCrashDirectory(context3);
            String absolutePath = nativeCrashDirectory != null ? nativeCrashDirectory.getAbsolutePath() : null;
            if (absolutePath != null) {
                c0335ieR.a.init(context3, new NativeCrashServiceConfig(absolutePath));
                List<NativeCrash> allCrashes = c0335ieR.a.getAllCrashes();
                if (!allCrashes.isEmpty()) {
                    C0206de c0206deB = c0335ieR.b.b(context3, c0157bh);
                    Iterator<T> it = allCrashes.iterator();
                    while (it.hasNext()) {
                        c0206deB.newCrash((NativeCrash) it.next());
                    }
                }
                c0335ieR.a.setDefaultCrashHandler(c0335ieR.b.a(context3, c0157bh));
            }
            new Y5(CollectionsKt.listOf(new RunnableC0337ih())).run();
            this.a = true;
        }
        Ka.I.l().a();
    }

    @Override // io.appmetrica.analytics.impl.C1
    public final void onDestroy() {
        C0152bc c0152bcL = Ka.I.l();
        synchronized (c0152bcL) {
            ArrayList arrayList = c0152bcL.c;
            int size = arrayList.size();
            int i = 0;
            while (i < size) {
                Object obj = arrayList.get(i);
                i++;
                ((Ck) obj).onDestroy();
            }
        }
    }

    @Override // io.appmetrica.analytics.impl.C1
    public final void pauseUserSession(Bundle bundle) {
        Wf wf;
        bundle.setClassLoader(Wf.class.getClassLoader());
        String str = Wf.c;
        try {
            wf = (Wf) bundle.getParcelable("PROCESS_CFG_OBJ");
        } catch (Throwable unused) {
            wf = null;
        }
        Integer asInteger = wf != null ? wf.a.getAsInteger("PROCESS_CFG_PROCESS_ID") : null;
        if (asInteger != null) {
            this.h.b(asInteger.intValue());
        }
    }

    @Override // io.appmetrica.analytics.impl.C1
    public final void reportData(int i, Bundle bundle) {
        this.j.getClass();
        List listEmptyList = (List) Ka.I.v.a.get(Integer.valueOf(i));
        if (listEmptyList == null) {
            listEmptyList = CollectionsKt.emptyList();
        }
        if (listEmptyList.isEmpty()) {
            return;
        }
        Iterator it = listEmptyList.iterator();
        while (it.hasNext()) {
            ((InterfaceC0652uk) it.next()).reportData(i, bundle);
        }
    }

    @Override // io.appmetrica.analytics.impl.C1
    public final void resumeUserSession(Bundle bundle) {
        Wf wf;
        bundle.setClassLoader(Wf.class.getClassLoader());
        String str = Wf.c;
        try {
            wf = (Wf) bundle.getParcelable("PROCESS_CFG_OBJ");
        } catch (Throwable unused) {
            wf = null;
        }
        Integer asInteger = wf != null ? wf.a.getAsInteger("PROCESS_CFG_PROCESS_ID") : null;
        if (asInteger != null) {
            this.h.c(asInteger.intValue());
        }
    }

    public O1(Context context, B1 b1, C0611t5 c0611t5) {
        this(context, b1, new C0558r4(context, c0611t5), new W1(), Ba.d, Ka.k().e(), new P1());
    }

    @Override // io.appmetrica.analytics.impl.C1
    public final void a(Intent intent) {
        W1 w1 = this.e;
        if (intent != null) {
            w1.getClass();
            String action = intent.getAction();
            if (!TextUtils.isEmpty(action)) {
                w1.a.a(action, Integer.valueOf(W1.a(intent)));
            }
            for (Map.Entry entry : w1.b.entrySet()) {
                V1 v1 = (V1) entry.getKey();
                if (((U1) entry.getValue()).a(intent)) {
                    v1.a(intent);
                }
            }
            return;
        }
        w1.getClass();
    }

    public O1(Context context, B1 b1, C0558r4 c0558r4, W1 w1, Ba ba, C0608t2 c0608t2, P1 p1) {
        this.a = false;
        this.b = context;
        this.c = b1;
        this.d = c0558r4;
        this.e = w1;
        this.g = ba;
        this.h = c0608t2;
        this.i = p1;
        this.j = new C0546qh();
    }

    public final void a(Bundle bundle) {
        bundle.setClassLoader(CounterConfiguration.class.getClassLoader());
        C0249f6.b(bundle);
        C0157bh c0157bh = this.f;
        if (c0157bh != null) {
            c0157bh.a(C0249f6.b(bundle), bundle);
        }
    }

    @Override // io.appmetrica.analytics.impl.C1
    public final void a(Intent intent, int i) {
        ((C0684w0) this.c).a.stopSelf(i);
    }

    @Override // io.appmetrica.analytics.impl.C1
    public final void a(Intent intent, int i, int i2) {
        ((C0684w0) this.c).a.stopSelf(i2);
    }
}
