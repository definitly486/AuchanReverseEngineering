package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import io.appmetrica.analytics.BuildConfig;
import io.appmetrica.analytics.coreutils.internal.executors.BlockingExecutor;
import io.appmetrica.analytics.coreutils.internal.executors.SynchronizedBlockingExecutor;
import io.appmetrica.analytics.coreutils.internal.network.UserAgent;
import io.appmetrica.analytics.networktasks.internal.AESRSARequestBodyEncrypter;
import io.appmetrica.analytics.networktasks.internal.AllHostsExponentialBackoffPolicy;
import io.appmetrica.analytics.networktasks.internal.DefaultResponseValidityChecker;
import io.appmetrica.analytics.networktasks.internal.ExponentialBackoffDataHolder;
import io.appmetrica.analytics.networktasks.internal.FinalConfigProvider;
import io.appmetrica.analytics.networktasks.internal.FullUrlFormer;
import io.appmetrica.analytics.networktasks.internal.NetworkTask;
import io.appmetrica.analytics.networktasks.internal.RequestDataHolder;
import io.appmetrica.analytics.networktasks.internal.ResponseDataHolder;
import java.util.LinkedHashMap;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.qe, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0543qe {
    public static final C0543qe a = new C0543qe();
    public static final LinkedHashMap b = new LinkedHashMap();
    public static final String c = UserAgent.getFor(BuildConfig.LIBRARY_PACKAGE_NAME, "8.1.0", "50162358");

    public static final NetworkTask a(C0455n5 c0455n5) {
        ExponentialBackoffDataHolder exponentialBackoffDataHolder;
        AESRSARequestBodyEncrypter aESRSARequestBodyEncrypter = new AESRSARequestBodyEncrypter();
        C0441mh c0441mh = new C0441mh(aESRSARequestBodyEncrypter);
        Ub ub = new Ub(c0455n5);
        BlockingExecutor blockingExecutor = new BlockingExecutor();
        F5 f5 = new F5(c0455n5.a);
        C0543qe c0543qe = a;
        EnumC0490oe enumC0490oe = EnumC0490oe.REPORT;
        synchronized (c0543qe) {
            try {
                LinkedHashMap linkedHashMap = b;
                Object exponentialBackoffDataHolder2 = linkedHashMap.get(enumC0490oe);
                if (exponentialBackoffDataHolder2 == null) {
                    exponentialBackoffDataHolder2 = new ExponentialBackoffDataHolder(new Wa(Ka.I.y(), enumC0490oe), "REPORT");
                    linkedHashMap.put(enumC0490oe, exponentialBackoffDataHolder2);
                }
                exponentialBackoffDataHolder = (ExponentialBackoffDataHolder) exponentialBackoffDataHolder2;
            } catch (Throwable th) {
                throw th;
            }
        }
        return new NetworkTask(blockingExecutor, f5, new AllHostsExponentialBackoffPolicy(exponentialBackoffDataHolder), new Gh(c0455n5, c0441mh, ub, new FullUrlFormer(c0441mh, ub), new RequestDataHolder(), new ResponseDataHolder(new DefaultResponseValidityChecker()), aESRSARequestBodyEncrypter), CollectionsKt.listOf(new Co()), c);
    }

    public static final NetworkTask a(Rm rm, C0602sm c0602sm) {
        ExponentialBackoffDataHolder exponentialBackoffDataHolder;
        C0498om c0498om = new C0498om(new Ce(), Ka.I.p());
        FinalConfigProvider finalConfigProvider = new FinalConfigProvider(c0602sm);
        SynchronizedBlockingExecutor synchronizedBlockingExecutor = new SynchronizedBlockingExecutor();
        F5 f5 = new F5(rm.a.a);
        C0543qe c0543qe = a;
        EnumC0490oe enumC0490oe = EnumC0490oe.STARTUP;
        synchronized (c0543qe) {
            try {
                LinkedHashMap linkedHashMap = b;
                Object exponentialBackoffDataHolder2 = linkedHashMap.get(enumC0490oe);
                if (exponentialBackoffDataHolder2 == null) {
                    exponentialBackoffDataHolder2 = new ExponentialBackoffDataHolder(new Wa(Ka.I.y(), enumC0490oe), "STARTUP");
                    linkedHashMap.put(enumC0490oe, exponentialBackoffDataHolder2);
                }
                exponentialBackoffDataHolder = (ExponentialBackoffDataHolder) exponentialBackoffDataHolder2;
            } catch (Throwable th) {
                throw th;
            }
        }
        return new NetworkTask(synchronizedBlockingExecutor, f5, new AllHostsExponentialBackoffPolicy(exponentialBackoffDataHolder), new Pm(rm, new C0342im(), new FullUrlFormer(c0498om, finalConfigProvider), new RequestDataHolder(), new ResponseDataHolder(new DefaultResponseValidityChecker()), finalConfigProvider), CollectionsKt.emptyList(), c);
    }
}
