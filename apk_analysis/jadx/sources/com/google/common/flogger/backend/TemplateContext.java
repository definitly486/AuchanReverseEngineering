package com.google.common.flogger.backend;

import com.google.common.flogger.parser.MessageParser;
import com.google.common.flogger.util.Checks;

/* JADX INFO: loaded from: classes2.dex */
public final class TemplateContext {
    private final String message;
    private final MessageParser parser;

    public TemplateContext(MessageParser messageParser, String str) {
        this.parser = (MessageParser) Checks.checkNotNull(messageParser, "parser");
        this.message = (String) Checks.checkNotNull(str, "message");
    }

    public MessageParser getParser() {
        return this.parser;
    }

    public String getMessage() {
        return this.message;
    }

    public boolean equals(Object obj) {
        if (obj instanceof TemplateContext) {
            TemplateContext templateContext = (TemplateContext) obj;
            if (this.parser.equals(templateContext.parser) && this.message.equals(templateContext.message)) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return this.parser.hashCode() ^ this.message.hashCode();
    }
}
