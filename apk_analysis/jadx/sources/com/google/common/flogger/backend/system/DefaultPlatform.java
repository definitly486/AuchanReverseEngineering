package com.google.common.flogger.backend.system;

import com.google.common.flogger.backend.LoggerBackend;
import com.google.common.flogger.backend.Platform;
import com.google.common.flogger.context.ContextDataProvider;
import com.google.common.flogger.util.StaticMethodCaller;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.ServiceLoader;

/* JADX INFO: loaded from: classes2.dex */
public class DefaultPlatform extends Platform {
    private static final String BACKEND_FACTORY = "flogger.backend_factory";
    private static final String CLOCK = "flogger.clock";
    private static final String CONTEXT_DATA_PROVIDER = "flogger.logging_context";
    private final BackendFactory backendFactory;
    private final Platform.LogCallerFinder callerFinder;
    private final Clock clock;
    private final ContextDataProvider context;

    public DefaultPlatform() {
        BackendFactory backendFactory = (BackendFactory) loadService(BackendFactory.class, BACKEND_FACTORY);
        this.backendFactory = backendFactory == null ? SimpleBackendFactory.getInstance() : backendFactory;
        ContextDataProvider contextDataProvider = (ContextDataProvider) loadService(ContextDataProvider.class, CONTEXT_DATA_PROVIDER);
        this.context = contextDataProvider == null ? ContextDataProvider.getNoOpProvider() : contextDataProvider;
        Clock clock = (Clock) loadService(Clock.class, CLOCK);
        this.clock = clock == null ? SystemClock.getInstance() : clock;
        this.callerFinder = StackBasedCallerFinder.getInstance();
    }

    private static <S> S loadService(Class<S> cls, String str) {
        S s = (S) StaticMethodCaller.getInstanceFromSystemProperty(str, cls);
        if (s != null) {
            return s;
        }
        ArrayList arrayList = new ArrayList();
        Iterator<S> it = ServiceLoader.load(cls).iterator();
        while (it.hasNext()) {
            arrayList.add(it.next());
        }
        int size = arrayList.size();
        if (size == 0) {
            return null;
        }
        if (size == 1) {
            return (S) arrayList.get(0);
        }
        System.err.printf("Multiple implementations of service %s found on the classpath: %s%nEnsure only the service implementation you want to use is included on the classpath or else specify the service class at startup with the '%s' system property. The default implementation will be used instead.%n", cls.getName(), arrayList, str);
        return null;
    }

    DefaultPlatform(BackendFactory backendFactory, ContextDataProvider contextDataProvider, Clock clock, Platform.LogCallerFinder logCallerFinder) {
        this.backendFactory = backendFactory;
        this.context = contextDataProvider;
        this.clock = clock;
        this.callerFinder = logCallerFinder;
    }

    @Override // com.google.common.flogger.backend.Platform
    protected Platform.LogCallerFinder getCallerFinderImpl() {
        return this.callerFinder;
    }

    @Override // com.google.common.flogger.backend.Platform
    protected LoggerBackend getBackendImpl(String str) {
        return this.backendFactory.create(str);
    }

    @Override // com.google.common.flogger.backend.Platform
    protected ContextDataProvider getContextDataProviderImpl() {
        return this.context;
    }

    @Override // com.google.common.flogger.backend.Platform
    protected long getCurrentTimeNanosImpl() {
        return this.clock.getCurrentTimeNanos();
    }

    @Override // com.google.common.flogger.backend.Platform
    protected String getConfigInfoImpl() {
        return "Platform: " + getClass().getName() + "\nBackendFactory: " + this.backendFactory + "\nClock: " + this.clock + "\nContextDataProvider: " + this.context + "\nLogCallerFinder: " + this.callerFinder + "\n";
    }
}
