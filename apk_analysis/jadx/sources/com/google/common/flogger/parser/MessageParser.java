package com.google.common.flogger.parser;

/* JADX INFO: loaded from: classes2.dex */
public abstract class MessageParser {
    public static final int MAX_ARG_COUNT = 1000000;

    protected abstract <T> void parseImpl(MessageBuilder<T> messageBuilder);

    public abstract void unescape(StringBuilder sb, String str, int i, int i2);
}
