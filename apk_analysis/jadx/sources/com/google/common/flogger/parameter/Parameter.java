package com.google.common.flogger.parameter;

import com.google.common.flogger.backend.FormatOptions;

/* JADX INFO: loaded from: classes2.dex */
public abstract class Parameter {
    private final int index;
    private final FormatOptions options;

    protected abstract void accept(ParameterVisitor parameterVisitor, Object obj);

    public abstract String getFormat();

    protected Parameter(FormatOptions formatOptions, int i) {
        if (formatOptions == null) {
            throw new IllegalArgumentException("format options cannot be null");
        }
        if (i < 0) {
            throw new IllegalArgumentException("invalid index: " + i);
        }
        this.index = i;
        this.options = formatOptions;
    }

    public final int getIndex() {
        return this.index;
    }

    protected final FormatOptions getFormatOptions() {
        return this.options;
    }

    public final void accept(ParameterVisitor parameterVisitor, Object[] objArr) {
        if (getIndex() < objArr.length) {
            Object obj = objArr[getIndex()];
            if (obj != null) {
                accept(parameterVisitor, obj);
                return;
            } else {
                parameterVisitor.visitNull();
                return;
            }
        }
        parameterVisitor.visitMissing();
    }
}
