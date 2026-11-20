package com.google.common.flogger.backend;

import com.google.common.flogger.AbstractLogger;
import com.google.common.flogger.LogSite;
import com.google.common.flogger.context.ContextDataProvider;
import com.google.common.flogger.context.Tags;
import com.google.common.flogger.util.RecursionDepth;
import java.lang.reflect.InvocationTargetException;
import java.util.concurrent.TimeUnit;
import java.util.logging.Level;

/* JADX INFO: loaded from: classes2.dex */
public abstract class Platform {
    private static final String[] AVAILABLE_PLATFORMS = {"com.google.common.flogger.backend.system.DefaultPlatform"};
    private static String DEFAULT_PLATFORM = "com.google.common.flogger.backend.system.DefaultPlatform";

    public static abstract class LogCallerFinder {
        public abstract LogSite findLogSite(Class<?> cls, int i);

        public abstract String findLoggingClass(Class<? extends AbstractLogger<?>> cls);
    }

    protected abstract LoggerBackend getBackendImpl(String str);

    protected abstract LogCallerFinder getCallerFinderImpl();

    protected abstract String getConfigInfoImpl();

    private static final class LazyHolder {
        private static final Platform INSTANCE = loadFirstAvailablePlatform(Platform.AVAILABLE_PLATFORMS);

        private LazyHolder() {
        }

        private static Platform loadFirstAvailablePlatform(String[] strArr) {
            Platform platform;
            try {
                platform = PlatformProvider.getPlatform();
            } catch (NoClassDefFoundError unused) {
                platform = null;
            }
            if (platform != null) {
                return platform;
            }
            StringBuilder sb = new StringBuilder();
            for (String str : strArr) {
                try {
                    return (Platform) Class.forName(str).getConstructor(null).newInstance(null);
                } catch (Throwable th) {
                    th = th;
                    sb.append('\n');
                    sb.append(str);
                    sb.append(": ");
                    if (th instanceof InvocationTargetException) {
                        th = th.getCause();
                    }
                    sb.append(th);
                }
            }
            throw new IllegalStateException(sb.insert(0, "No logging platforms found:").toString());
        }
    }

    public static int getCurrentRecursionDepth() {
        return RecursionDepth.getCurrentDepth();
    }

    public static LogCallerFinder getCallerFinder() {
        return LazyHolder.INSTANCE.getCallerFinderImpl();
    }

    public static LoggerBackend getBackend(String str) {
        return LazyHolder.INSTANCE.getBackendImpl(str);
    }

    public static ContextDataProvider getContextDataProvider() {
        return LazyHolder.INSTANCE.getContextDataProviderImpl();
    }

    protected ContextDataProvider getContextDataProviderImpl() {
        return ContextDataProvider.getNoOpProvider();
    }

    public static boolean shouldForceLogging(String str, Level level, boolean z) {
        return getContextDataProvider().shouldForceLogging(str, level, z);
    }

    public static Tags getInjectedTags() {
        return getContextDataProvider().getTags();
    }

    public static Metadata getInjectedMetadata() {
        return getContextDataProvider().getMetadata();
    }

    public static long getCurrentTimeNanos() {
        return LazyHolder.INSTANCE.getCurrentTimeNanosImpl();
    }

    protected long getCurrentTimeNanosImpl() {
        return TimeUnit.MILLISECONDS.toNanos(System.currentTimeMillis());
    }

    public static String getConfigInfo() {
        return LazyHolder.INSTANCE.getConfigInfoImpl();
    }
}
