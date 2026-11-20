package com.google.common.flogger.parameter;

import com.google.common.flogger.backend.FormatOptions;

/* JADX INFO: loaded from: classes2.dex */
public final class DateTimeParameter extends Parameter {
    private final DateTimeFormat format;
    private final String formatString;

    public static Parameter of(DateTimeFormat dateTimeFormat, FormatOptions formatOptions, int i) {
        return new DateTimeParameter(formatOptions, i, dateTimeFormat);
    }

    private DateTimeParameter(FormatOptions formatOptions, int i, DateTimeFormat dateTimeFormat) {
        super(formatOptions, i);
        this.format = dateTimeFormat;
        StringBuilder sbAppendPrintfOptions = formatOptions.appendPrintfOptions(new StringBuilder("%"));
        sbAppendPrintfOptions.append(formatOptions.shouldUpperCase() ? 'T' : 't');
        sbAppendPrintfOptions.append(dateTimeFormat.getChar());
        this.formatString = sbAppendPrintfOptions.toString();
    }

    @Override // com.google.common.flogger.parameter.Parameter
    protected void accept(ParameterVisitor parameterVisitor, Object obj) {
        parameterVisitor.visitDateTime(obj, this.format, getFormatOptions());
    }

    @Override // com.google.common.flogger.parameter.Parameter
    public String getFormat() {
        return this.formatString;
    }
}
