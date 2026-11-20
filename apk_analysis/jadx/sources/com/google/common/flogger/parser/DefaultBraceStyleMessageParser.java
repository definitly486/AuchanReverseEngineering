package com.google.common.flogger.parser;

import com.google.common.flogger.parameter.BraceStyleParameter;

/* JADX INFO: loaded from: classes2.dex */
public class DefaultBraceStyleMessageParser extends BraceStyleMessageParser {
    private static final BraceStyleMessageParser INSTANCE = new DefaultBraceStyleMessageParser();

    public static BraceStyleMessageParser getInstance() {
        return INSTANCE;
    }

    private DefaultBraceStyleMessageParser() {
    }

    @Override // com.google.common.flogger.parser.BraceStyleMessageParser
    public void parseBraceFormatTerm(MessageBuilder<?> messageBuilder, int i, String str, int i2, int i3, int i4) {
        if (i3 != -1) {
            throw ParseException.withBounds("the default brace style parser does not allow trailing format specifiers", str, i3 - 1, i4 - 1);
        }
        messageBuilder.addParameter(i2, i4, BraceStyleParameter.of(i));
    }
}
