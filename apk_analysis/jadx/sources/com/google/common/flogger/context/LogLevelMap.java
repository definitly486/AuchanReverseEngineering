package com.google.common.flogger.context;

import com.google.common.flogger.util.Checks;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.logging.Level;

/* JADX INFO: loaded from: classes2.dex */
public final class LogLevelMap {
    private final SegmentTrie<Level> trie;

    public static final class Builder {
        private Level defaultLevel;
        private final Map<String, Level> map;

        private Builder() {
            this.map = new HashMap();
            this.defaultLevel = Level.OFF;
        }

        private void put(String str, Level level) {
            if (this.map.put(str, level) == null) {
                return;
            }
            throw new IllegalArgumentException("duplicate entry for class/package: " + str);
        }

        @CanIgnoreReturnValue
        public Builder add(Level level, Class<?>... clsArr) {
            for (Class<?> cls : clsArr) {
                put(cls.getName(), level);
            }
            return this;
        }

        @CanIgnoreReturnValue
        public Builder add(Level level, Package... packageArr) {
            for (Package r0 : packageArr) {
                put(r0.getName(), level);
            }
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setDefault(Level level) {
            Checks.checkNotNull(this.defaultLevel, "default log level must not be null");
            this.defaultLevel = level;
            return this;
        }

        public LogLevelMap build() {
            return LogLevelMap.create(this.map, this.defaultLevel);
        }
    }

    public static Builder builder() {
        return new Builder();
    }

    public static LogLevelMap create(Level level) {
        return create(Collections.EMPTY_MAP, level);
    }

    public static LogLevelMap create(Map<String, ? extends Level> map) {
        return create(map, Level.OFF);
    }

    public static LogLevelMap create(Map<String, ? extends Level> map, Level level) {
        Checks.checkNotNull(level, "default log level must not be null");
        for (Map.Entry<String, ? extends Level> entry : map.entrySet()) {
            String key = entry.getKey();
            if (key.startsWith(".") || key.endsWith(".") || key.contains("..")) {
                throw new IllegalArgumentException("invalid logger name: " + key);
            }
            if (entry.getValue() == null) {
                throw new IllegalArgumentException("log levels must not be null; logger=" + key);
            }
        }
        return new LogLevelMap(map, level);
    }

    private LogLevelMap(Map<String, ? extends Level> map, Level level) {
        this.trie = SegmentTrie.create(map, '.', level);
    }

    public Level getLevel(String str) {
        return this.trie.find(str);
    }

    public LogLevelMap merge(LogLevelMap logLevelMap) {
        Map<String, Level> entryMap = this.trie.getEntryMap();
        Map<String, Level> entryMap2 = logLevelMap.trie.getEntryMap();
        HashMap map = new HashMap();
        HashSet<String> hashSet = new HashSet(entryMap.keySet());
        hashSet.addAll(entryMap2.keySet());
        for (String str : hashSet) {
            if (!entryMap2.containsKey(str)) {
                map.put(str, entryMap.get(str));
            } else if (!entryMap.containsKey(str)) {
                map.put(str, entryMap2.get(str));
            } else {
                map.put(str, min(entryMap.get(str), entryMap2.get(str)));
            }
        }
        return create(map, min(this.trie.getDefaultValue(), logLevelMap.trie.getDefaultValue()));
    }

    private static Level min(Level level, Level level2) {
        return level.intValue() <= level2.intValue() ? level : level2;
    }
}
