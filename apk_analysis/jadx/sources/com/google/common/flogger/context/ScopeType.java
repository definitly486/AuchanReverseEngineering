package com.google.common.flogger.context;

import com.google.common.flogger.LoggingScope;
import com.google.common.flogger.LoggingScopeProvider;
import com.google.common.flogger.util.Checks;

/* JADX INFO: loaded from: classes2.dex */
public final class ScopeType implements LoggingScopeProvider {
    public static final ScopeType REQUEST = create("request");
    private final String name;

    public static ScopeType create(String str) {
        return new ScopeType(str);
    }

    private ScopeType(String str) {
        this.name = (String) Checks.checkNotNull(str, "name");
    }

    LoggingScope newScope() {
        return LoggingScope.create(this.name);
    }

    @Override // com.google.common.flogger.LoggingScopeProvider
    public LoggingScope getCurrentScope() {
        return ContextDataProvider.getInstance().getScope(this);
    }
}
