package com.google.mediapipe.tasks.core;

import com.google.mediapipe.tasks.core.TaskOptions;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_TaskInfo<T extends TaskOptions> extends TaskInfo<T> {
    private final boolean enableFlowLimiting;
    private final List<String> inputStreams;
    private final List<String> outputStreams;
    private final String taskGraphName;
    private final String taskName;
    private final T taskOptions;
    private final String taskRunningModeName;

    private AutoValue_TaskInfo(String str, String str2, String str3, T t, List<String> list, List<String> list2, boolean z) {
        this.taskName = str;
        this.taskRunningModeName = str2;
        this.taskGraphName = str3;
        this.taskOptions = t;
        this.inputStreams = list;
        this.outputStreams = list2;
        this.enableFlowLimiting = z;
    }

    @Override // com.google.mediapipe.tasks.core.TaskInfo
    String taskName() {
        return this.taskName;
    }

    @Override // com.google.mediapipe.tasks.core.TaskInfo
    String taskRunningModeName() {
        return this.taskRunningModeName;
    }

    @Override // com.google.mediapipe.tasks.core.TaskInfo
    String taskGraphName() {
        return this.taskGraphName;
    }

    @Override // com.google.mediapipe.tasks.core.TaskInfo
    T taskOptions() {
        return this.taskOptions;
    }

    @Override // com.google.mediapipe.tasks.core.TaskInfo
    List<String> inputStreams() {
        return this.inputStreams;
    }

    @Override // com.google.mediapipe.tasks.core.TaskInfo
    List<String> outputStreams() {
        return this.outputStreams;
    }

    @Override // com.google.mediapipe.tasks.core.TaskInfo
    boolean enableFlowLimiting() {
        return this.enableFlowLimiting;
    }

    public String toString() {
        return "TaskInfo{taskName=" + this.taskName + ", taskRunningModeName=" + this.taskRunningModeName + ", taskGraphName=" + this.taskGraphName + ", taskOptions=" + this.taskOptions + ", inputStreams=" + this.inputStreams + ", outputStreams=" + this.outputStreams + ", enableFlowLimiting=" + this.enableFlowLimiting + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof TaskInfo) {
            TaskInfo taskInfo = (TaskInfo) obj;
            if (this.taskName.equals(taskInfo.taskName()) && this.taskRunningModeName.equals(taskInfo.taskRunningModeName()) && this.taskGraphName.equals(taskInfo.taskGraphName()) && this.taskOptions.equals(taskInfo.taskOptions()) && this.inputStreams.equals(taskInfo.inputStreams()) && this.outputStreams.equals(taskInfo.outputStreams()) && this.enableFlowLimiting == taskInfo.enableFlowLimiting()) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return ((((((((((((this.taskName.hashCode() ^ 1000003) * 1000003) ^ this.taskRunningModeName.hashCode()) * 1000003) ^ this.taskGraphName.hashCode()) * 1000003) ^ this.taskOptions.hashCode()) * 1000003) ^ this.inputStreams.hashCode()) * 1000003) ^ this.outputStreams.hashCode()) * 1000003) ^ (this.enableFlowLimiting ? 1231 : 1237);
    }

    static final class Builder<T extends TaskOptions> extends TaskInfo.Builder<T> {
        private Boolean enableFlowLimiting;
        private List<String> inputStreams;
        private List<String> outputStreams;
        private String taskGraphName;
        private String taskName;
        private T taskOptions;
        private String taskRunningModeName;

        Builder() {
        }

        @Override // com.google.mediapipe.tasks.core.TaskInfo.Builder
        public TaskInfo.Builder<T> setTaskName(String str) {
            if (str == null) {
                throw new NullPointerException("Null taskName");
            }
            this.taskName = str;
            return this;
        }

        @Override // com.google.mediapipe.tasks.core.TaskInfo.Builder
        public TaskInfo.Builder<T> setTaskRunningModeName(String str) {
            if (str == null) {
                throw new NullPointerException("Null taskRunningModeName");
            }
            this.taskRunningModeName = str;
            return this;
        }

        @Override // com.google.mediapipe.tasks.core.TaskInfo.Builder
        public TaskInfo.Builder<T> setTaskGraphName(String str) {
            if (str == null) {
                throw new NullPointerException("Null taskGraphName");
            }
            this.taskGraphName = str;
            return this;
        }

        @Override // com.google.mediapipe.tasks.core.TaskInfo.Builder
        public TaskInfo.Builder<T> setTaskOptions(T t) {
            if (t == null) {
                throw new NullPointerException("Null taskOptions");
            }
            this.taskOptions = t;
            return this;
        }

        @Override // com.google.mediapipe.tasks.core.TaskInfo.Builder
        public TaskInfo.Builder<T> setInputStreams(List<String> list) {
            if (list == null) {
                throw new NullPointerException("Null inputStreams");
            }
            this.inputStreams = list;
            return this;
        }

        @Override // com.google.mediapipe.tasks.core.TaskInfo.Builder
        public TaskInfo.Builder<T> setOutputStreams(List<String> list) {
            if (list == null) {
                throw new NullPointerException("Null outputStreams");
            }
            this.outputStreams = list;
            return this;
        }

        @Override // com.google.mediapipe.tasks.core.TaskInfo.Builder
        public TaskInfo.Builder<T> setEnableFlowLimiting(boolean z) {
            this.enableFlowLimiting = Boolean.valueOf(z);
            return this;
        }

        @Override // com.google.mediapipe.tasks.core.TaskInfo.Builder
        public TaskInfo<T> autoBuild() {
            String str = "";
            if (this.taskName == null) {
                str = " taskName";
            }
            if (this.taskRunningModeName == null) {
                str = str + " taskRunningModeName";
            }
            if (this.taskGraphName == null) {
                str = str + " taskGraphName";
            }
            if (this.taskOptions == null) {
                str = str + " taskOptions";
            }
            if (this.inputStreams == null) {
                str = str + " inputStreams";
            }
            if (this.outputStreams == null) {
                str = str + " outputStreams";
            }
            if (this.enableFlowLimiting == null) {
                str = str + " enableFlowLimiting";
            }
            if (!str.isEmpty()) {
                throw new IllegalStateException("Missing required properties:" + str);
            }
            return new AutoValue_TaskInfo(this.taskName, this.taskRunningModeName, this.taskGraphName, this.taskOptions, this.inputStreams, this.outputStreams, this.enableFlowLimiting.booleanValue());
        }
    }
}
