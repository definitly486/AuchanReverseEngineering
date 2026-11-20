package com.google.common.flogger;

import com.google.common.flogger.util.Checks;
import java.lang.ref.ReferenceQueue;
import java.lang.ref.WeakReference;
import java.util.Queue;
import java.util.concurrent.ConcurrentLinkedQueue;

/* JADX INFO: loaded from: classes2.dex */
public abstract class LoggingScope {
    private final String label;

    protected abstract void onClose(Runnable runnable);

    protected abstract LogSiteKey specialize(LogSiteKey logSiteKey);

    public static LoggingScope create(String str) {
        return new WeakScope((String) Checks.checkNotNull(str, "label"));
    }

    protected LoggingScope(String str) {
        this.label = str;
    }

    public final String toString() {
        return this.label;
    }

    static final class WeakScope extends LoggingScope {
        private final KeyPart keyPart;

        public WeakScope(String str) {
            super(str);
            this.keyPart = new KeyPart(this);
        }

        @Override // com.google.common.flogger.LoggingScope
        protected LogSiteKey specialize(LogSiteKey logSiteKey) {
            return SpecializedLogSiteKey.of(logSiteKey, this.keyPart);
        }

        @Override // com.google.common.flogger.LoggingScope
        protected void onClose(Runnable runnable) {
            KeyPart.removeUnusedKeys();
            this.keyPart.onCloseHooks.offer(runnable);
        }

        void closeForTesting() {
            this.keyPart.close();
        }

        private static class KeyPart extends WeakReference<LoggingScope> {
            private static final ReferenceQueue<LoggingScope> queue = new ReferenceQueue<>();
            private final Queue<Runnable> onCloseHooks;

            KeyPart(LoggingScope loggingScope) {
                super(loggingScope, queue);
                this.onCloseHooks = new ConcurrentLinkedQueue();
            }

            static void removeUnusedKeys() {
                while (true) {
                    KeyPart keyPart = (KeyPart) queue.poll();
                    if (keyPart == null) {
                        return;
                    } else {
                        keyPart.close();
                    }
                }
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void close() {
                while (true) {
                    Runnable runnablePoll = this.onCloseHooks.poll();
                    if (runnablePoll == null) {
                        return;
                    } else {
                        runnablePoll.run();
                    }
                }
            }
        }
    }
}
