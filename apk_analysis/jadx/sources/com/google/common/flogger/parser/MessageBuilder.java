package com.google.common.flogger.parser;

import com.google.common.flogger.backend.TemplateContext;
import com.google.common.flogger.parameter.Parameter;
import com.google.common.flogger.util.Checks;

/* JADX INFO: loaded from: classes2.dex */
public abstract class MessageBuilder<T> {
    private final TemplateContext context;
    private int pmask = 0;
    private int maxIndex = -1;

    protected abstract void addParameterImpl(int i, int i2, Parameter parameter);

    protected abstract T buildImpl();

    public MessageBuilder(TemplateContext templateContext) {
        this.context = (TemplateContext) Checks.checkNotNull(templateContext, "context");
    }

    public final MessageParser getParser() {
        return this.context.getParser();
    }

    public final String getMessage() {
        return this.context.getMessage();
    }

    public final int getExpectedArgumentCount() {
        return this.maxIndex + 1;
    }

    public final void addParameter(int i, int i2, Parameter parameter) {
        if (parameter.getIndex() < 32) {
            this.pmask |= 1 << parameter.getIndex();
        }
        this.maxIndex = Math.max(this.maxIndex, parameter.getIndex());
        addParameterImpl(i, i2, parameter);
    }

    public final T build() {
        getParser().parseImpl(this);
        int i = this.pmask;
        if (((i + 1) & i) != 0 || (this.maxIndex > 31 && i != -1)) {
            throw ParseException.generic(String.format("unreferenced arguments [first missing index=%d]", Integer.valueOf(Integer.numberOfTrailingZeros(~i))), getMessage());
        }
        return buildImpl();
    }
}
